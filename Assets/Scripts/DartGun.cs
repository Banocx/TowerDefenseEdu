using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;





public class DartGun : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform barrelLocation;
    public float shotPower = 20000f;

    //Charger definitions
    public int magazineSize = 30;        // Tamaño del cargador
    public int totalAmmo = 50000;           // Número total de balas disponibles
    public float reloadTime = 2f;        // Tiempo de recarga en segundos

    private int currentMagazineAmmo;      // Número actual de balas en el cargador
    private bool isReloading = false;     // Bandera para evitar la recarga mientras ya se está recargando


    // Llamado al inicio del juego
    void Start()
    {
        currentMagazineAmmo = magazineSize;
    }


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && !isReloading)
        {
            // Iniciar la recarga si se presiona la tecla R y no se está recargando actualmente
            StartCoroutine(Reload());
        }

        // Verificar si el usuario presiona el botón de gatillo derecho
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Shoot();
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
