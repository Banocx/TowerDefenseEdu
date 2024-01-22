using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    public int magazineSize = 10;        // Tama�o del cargador
    public int totalAmmo = 50;           // N�mero total de balas disponibles
    public float reloadTime = 2f;        // Tiempo de recarga en segundos

    private int currentMagazineAmmo;      // N�mero actual de balas en el cargador
    private bool isReloading = false;     // Bandera para evitar la recarga mientras ya se est� recargando

    // Llamado al inicio del juego
    void Start()
    {
        currentMagazineAmmo = magazineSize;
    }

    // Llamado en cada fotograma
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            // Iniciar la recarga si se presiona la tecla R y no se est� recargando actualmente
            StartCoroutine(Reload());
        }

        // Aqu� puedes agregar la l�gica para disparar y otras acciones relacionadas con el arma
        // ...

    }

    // Rutina de recarga
    IEnumerator Reload()
    {
        isReloading = true;

        // Calcular cu�ntas balas se deben recargar
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
