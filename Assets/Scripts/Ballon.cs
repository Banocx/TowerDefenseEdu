using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Ballon : NetworkBehaviour
{
    public GameObject[] waypoints;
    private int nextWayPointIndex=0;
    
    private Break_Ghost breakGhostScript;
    private Material m_Material;

    public float destroyDistance = 0.5f; // Distancia a la que se destruirá el globo
    public string endPointTag = "EndPoint"; // Tag del cubo de destino
    public static event Action<int> OnEnemyDestroyed; // Evento que notifica cuando un enemigo es destruido

    public static Ballon instance;
    public int healt = 1;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Try to get the attached Break_Ghost script 
        breakGhostScript = GetComponent<Break_Ghost>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");

        // Verify if the script was found
        if (breakGhostScript != null)
        {
            // The object has the Break_Ghost script 
            Debug.Log("Se encontró el script Break_Ghost");
        }
        else
        {
            // The object does not have the Break_Ghost script 
            Debug.Log("No se encontró el script Break_Ghost");
        }

        var random = UnityEngine.Random.Range(0, 2);
        string waypointsTag = (random == 0) ? "Waypoints" : "Waypoints2";
        waypoints = FindWaypointsByTag(waypointsTag);
        Array.Sort(waypoints, CompareObNames);
    }

    //Identify de path by tag

    private GameObject[] FindWaypointsByTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }



    //make a coparation name by name
    private int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }


    // Update is called once per frame
    void Update()
    {
        MoveBallon();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            healt--;

            if (healt <= 0)
            {
                // Verificar si se encontró el script Break_Ghost antes de acceder a sus propiedades o métodos
                if (breakGhostScript != null)
                {
                    breakGhostScript.Is_Breaked = true;

                    // Llama al método para destruir el objeto después de 4 segundos
                    Invoke("DestruirObjeto", 2f);


                    // Incrementar el contador de enemigos destruidos
                    OnEnemyDestroyed?.Invoke(1);

                    // Incrementar el contador local del DartGun
                    FindObjectOfType<DartGun>()?.IncrementEnemiesDestroyedNetwork();


                }
                else
                {
                                      
                    // Llama al método para destruir el objeto después de 2 segundos
                    Invoke("DestruirObjeto", 2f);

                    // Incrementar el contador local del DartGun
                    FindObjectOfType<DartGun>()?.IncrementEnemiesDestroyedNetwork();


                }


            }
        }
    }

    void DestruirObjeto()
    {
        // Destruye el objeto 
        Destroy(this.gameObject);
    }
    
    private void MoveBallon()
    {
        // Verificar que haya waypoints
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints array is null or empty.");
            return;
        }

        var lastWayPointIndex = waypoints.Length - 1;

        if (lastWayPointIndex < 0)
        {
            Debug.LogError("Waypoints array is empty.");
            return;
        }

        if (lastWayPointIndex < waypoints.Length)
        {
            Vector3 lastWayPoint = waypoints[lastWayPointIndex].transform.position + new Vector3(0, 2, 0);
            Vector3 nextWayPoint = waypoints[nextWayPointIndex].transform.position + new Vector3(0, 2, 0);
            Vector3 direction = nextWayPoint - transform.position;

            // If enemy is more than 0.1 meters from the last Waypoint
            if (Vector3.Distance(transform.position, nextWayPoint) < 0.5f && nextWayPointIndex < lastWayPointIndex)
            {
                nextWayPointIndex++;
            }

            // Increase index so if enemy reaches one waypoint
            if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
            {
                // Keep moving to next waypoint
                transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

                // Calcula la rotación para mirar en la dirección deseada
                Quaternion newRotation = Quaternion.LookRotation(direction, Vector3.up);

                // Aplica la rotación al objeto
                transform.rotation = newRotation;
            }

            // Comprueba si el globo ha alcanzado el último waypoint
            if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.5f)
            {
                Destroy(this.gameObject);
            }

            Collider[] colliders = Physics.OverlapSphere(transform.position, destroyDistance);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag(endPointTag))
                {
                    Destroy(this.gameObject);
                    return; // Sale del método si se destruye el globo
                }
            }
        }
    }
}
