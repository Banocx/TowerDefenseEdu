using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ballon : MonoBehaviour
{
    public GameObject[] waypoints;
    private int nextWayPointIndex=0;
    public int healt = 1;
    public int speed = 1;
    private Break_Ghost breakGhostScript;
    private Material m_Material;

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
            Debug.Log("Se encontr� el script Break_Ghost");
        }
        else
        {
            // The object does not have the Break_Ghost script 
            Debug.Log("No se encontr� el script Break_Ghost");
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
                // Verificar si se encontr� el script Break_Ghost antes de acceder a sus propiedades o m�todos
                if (breakGhostScript != null)
                {
                    breakGhostScript.Is_Breaked = true;

                    // Llama al m�todo para destruir el objeto despu�s de 4 segundos
                    Invoke("DestruirObjeto", 3f);
                }
                else
                {
                    // Destruye el objeto 
                    Destroy(this.gameObject);
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
        //Verificar que haya waypoints
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
            //If enemy is more than 0.1 meters from the last Waypoint
            if (Vector3.Distance(transform.position, nextWayPoint) < 0.5f && nextWayPointIndex < lastWayPointIndex)
            {
                nextWayPointIndex++;

            }

            //Increase  index so if enemy reaches one waypoint
            if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
            {
                //Keep moving to nex waypoint
                transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

                // Calcula la rotaci�n para mirar en la direcci�n deseada
                Quaternion newRotation = Quaternion.LookRotation(direction, Vector3.up);

                // Aplica la rotaci�n al objeto
                transform.rotation = newRotation;

            }


            if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.5f)
            {
                Destroy(this.gameObject);
            }
        }

    }
    
}
