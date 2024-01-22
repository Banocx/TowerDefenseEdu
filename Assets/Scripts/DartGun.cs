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

    void Update()
    {
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
}
