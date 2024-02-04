using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BalloonDestroyCounter : NetworkBehaviour
{

    // Contadores para enemigos destruidos local y en red
    private int destroyedEnemiesLocal = 0;
    private int destroyedEnemiesNetwork = 0;

    // Evento que notifica cuando un enemigo es destruido
    public static event Action<int> OnEnemyDestroyed;

    // Texto para mostrar el valor de enemigos destruidos
    public Text destroyedEnemiesText;


    private void Start()
    {
        // Inicializa el texto al valor actual de enemigos destruidos localmente
        UpdateDestroyedEnemiesText(destroyedEnemiesLocal);
    }

    // Método para incrementar el contador de enemigos destruidos localmente
    // Método para incrementar el contador de enemigos destruidos localmente
    public void IncrementDestroyedEnemiesLocal()
    {
        destroyedEnemiesLocal++;
        OnEnemyDestroyed?.Invoke(destroyedEnemiesLocal);

        // Actualiza el texto al valor actual de enemigos destruidos localmente
        UpdateDestroyedEnemiesText(destroyedEnemiesLocal);
    }

    // Método para incrementar el contador de enemigos destruidos en red
    public void IncrementDestroyedEnemiesNetwork()
    {
        destroyedEnemiesNetwork++;
        OnEnemyDestroyed?.Invoke(destroyedEnemiesNetwork);

        // Actualiza el texto al valor actual de enemigos destruidos en red
        UpdateDestroyedEnemiesText(destroyedEnemiesNetwork);
    }

    // Método para actualizar el texto con el valor actual de enemigos destruidos
    private void UpdateDestroyedEnemiesText(int value)
    {
        if (destroyedEnemiesText != null)
        {
            destroyedEnemiesText.text = "" + value*15;
        }
    }
}

