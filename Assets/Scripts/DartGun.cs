using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fusion;
using System;

public class DartGun : NetworkBehaviour
{
    public GameObject dartPrefab;
    public Transform barrelLocation;
    public float shotPower = 2000f;

    #region Definiciones_Cargayrecarga
    // Charger definitions
    public int magazineSize = 30;        // Tamaño del cargador
    public int totalAmmo = 5000;           // Número total de balas disponibles
    public float reloadTime = 2f;        // Tiempo de recarga en segundos

    private int currentMagazineAmmo;         // Número actual de balas en el cargador
    private bool isReloading = false;        // Bandera para evitar la recarga mientras ya se está recargando

    public Text ammoText;                   // Contador de Balas en texto
    #endregion

    public AudioClip shootSound;
    public AudioClip reloadSound;

    private AudioSource shootAudioSource;
    private AudioSource reloadAudioSource;

    public Text enemiesDestroyedText;       // Contador de Balas en texto

    private bool isSpawned = false;

    public static DartGun instance;
    public int enemiesDestroyed;       // Variable para contar enemigos destruidos



    // Evento que notifica cuando un enemigo es destruido en red
    public static event Action<int> OnEnemyDestroyedNetwork;


    private void Awake()
    {
        
    }
    // Llamado al inicio del juego
    void Start()
    {
        enemiesDestroyed = 0; //Inicializa el contador de enemigos
        currentMagazineAmmo = magazineSize;

        // Obtén las referencias a los componentes AudioSource
        shootAudioSource = gameObject.AddComponent<AudioSource>();
        reloadAudioSource = gameObject.AddComponent<AudioSource>();
        
        // Marcar como instanciado
        isSpawned = true;
    }

    void Update()
    {
        if (isSpawned)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && !isReloading)
            {
                StartCoroutine(Reload());
                //Debug.Log("Recarga iniciada");

                if (reloadSound != null)
                {
                    reloadAudioSource.PlayOneShot(reloadSound);
                }

            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) && currentMagazineAmmo > 0)
            {
                Shoot();

                //Debug.Log("Disparo"); // Agrega un mensaje de depuración
                currentMagazineAmmo--; // Disminuir la munición

                // Reproduce el sonido de disparo
                if (shootSound != null)
                {
                    shootAudioSource.PlayOneShot(shootSound);
                }
            }


            //Actualizar el texto del objeto de texto con el número de balas en el cargador
            //Debug.Log("Munición actual: " + currentMagazineAmmo); // Añade un mensaje de depuración
            ammoText.text = currentMagazineAmmo + " / " + magazineSize;

            // Actualizar el texto del objeto de texto con el número de enemigos destruidos
            if (enemiesDestroyedText != null)
            {
                enemiesDestroyedText.text = enemiesDestroyed + "";
            }
            else
            {
                Debug.LogError("enemiesDestroyedText is null. Make sure it's assigned in the Inspector.");
            }

        }
        

        
    }

    
    public override void FixedUpdateNetwork()
    {
        // Verificar la entrada para manejar la recarga y el disparo
        if (GetInput<DartGunInput>(out var input))
        {
            if (input.Recargar && !isReloading)
            {
                StartCoroutine(Reload());
            }

            if (input.Disparar && currentMagazineAmmo > 0)
            {
                Shoot();
            }
        }
    }
        void Shoot()
    {
        // Instantance a new dart in the location of the canyon
        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.rotation);

        // Obtain the desired address (the leadership of the canyon)
        Vector3 desiredDirection = barrelLocation.forward;

        // Guide the dart to be perpendicular to the output point
        dart.transform.LookAt(dart.transform.position + desiredDirection, Vector3.up);

        // Rotate 90 degrees on the X axis
        dart.transform.Rotate(-90f, 0f, 0f);

        // Add strength to the Dardo Rigidbody component
        dart.GetComponent<Rigidbody>().AddForce(desiredDirection * shotPower);

        // Destroy the dart after 3 seconds
        Destroy(dart, 3f);
    }
    #region Contador de enemigos destruidos

    
    // Función para obtener el contador de enemigos destruidos (local)
    public int GetEnemiesDestroyedLocal()
    {
        return enemiesDestroyed;
    }

    // Función para incrementar el contador de enemigos destruidos en red
    public void IncrementEnemiesDestroyedNetwork()
    {
        OnEnemyDestroyedNetwork?.Invoke(1);
    }
    #endregion

    public struct DartGunInput : INetworkInput
    {
        public bool Recargar;
        public bool Disparar;
    }
    // Rutina de recarga
    IEnumerator Reload()
    {
        isReloading = true;

        // Calcular cuántas balas se deben recargar
        int bulletsToReload = magazineSize - currentMagazineAmmo;
        if (totalAmmo < bulletsToReload)
        {
            bulletsToReload = totalAmmo;
        }

        // Simular el tiempo de recarga
        yield return new WaitForSeconds(reloadTime);

        // Realizar la recarga
        totalAmmo -= bulletsToReload;
        currentMagazineAmmo += bulletsToReload;

        isReloading = false;

        
    }
    
}

