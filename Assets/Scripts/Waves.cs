//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;



//public class Waves : MonoBehaviour
//{
//    public float difficulty = 0.4f;
//    public float difficultyIncreaseSpeed = 0.01f;
//    public Transform startPosition;
//    public GameObject ballonGreen;
//    public GameObject ballonBlue;
//    public GameObject ballonRed;
//    public GameObject ballonYellow;
//    public GameObject ballonPink;

//    //Timer
//    private float ballonTimer = 0f;
//    private float nextBallon = 1f;

//    //Ballon Limiter
//    public int ballonsPerWave = 20;
//    private int ballonsCount = 1;

//    //waves Timer
//    public float waveTimer = 30f;
//    public float nextWave = 20f;

//    // Countdown Timer
//    private float countdownTimer = 3f;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Begin de countdown
//        StartCoroutine(StartCountdown());
//    }
//    // Countdown Coroutine
//    IEnumerator StartCountdown()
//    {
//        while (countdownTimer > 0f)
//        {
//            yield return new WaitForSeconds(1f);
//            countdownTimer--;
//        }
//    }
//    // Update is called once per frame

//    // Update is called once per frame
//    void Update()
//    {
//        // Verifica si el contador está en cero
//        if (countdownTimer <= 0f)
//        {
//            // Lógica para enviar globos y crear olas después del contador
//            if (ballonTimer < Time.time && waveTimer < Time.time)
//            {
//                ballonsCount++;
//                difficulty += difficultyIncreaseSpeed;
//                ballonTimer = Time.time + nextBallon;

//                // Send Ballons Randomly

//                // Available balloons prefabs array
//                GameObject[] balloonPrefabs = { ballonBlue, ballonGreen, ballonRed, ballonYellow, ballonPink };

//                // Randomly select a prefab from ballon Array
//                int randomIndex = UnityEngine.Random.Range(0, balloonPrefabs.Length);
//                var selectedBalloonPrefab = balloonPrefabs[randomIndex];

//                // Instantance the randomly selected balloon
//                var balloon = Instantiate(selectedBalloonPrefab, startPosition.position, selectedBalloonPrefab.transform.rotation);

//                // Adjust the health and speed of the balloon based on the difficulty
//                balloon.GetComponent<Ballon>().healt += (int)Math.Round(difficulty);
//                balloon.GetComponent<Ballon>().speed += (int)Math.Round(difficulty);
//            }

//            // Create Waves
//            if (ballonsCount % ballonsPerWave == 0 && waveTimer < Time.time)
//            {
//                waveTimer = Time.time + nextWave;
//            }
//        }
//    }
//}
using System.Collections;
using UnityEngine;
using Fusion;

public class Waves : NetworkBehaviour
{
    public float dificultad = 0.4f;
    public float aumentoDificultad = 0.01f;
    public Transform posicionInicial;
    public GameObject globoVerde;
    public GameObject globoAzul;
    public GameObject globoRojo;
    public GameObject globoAmarillo;
    public GameObject globoRosa;

    // Temporizador del globo
    private float temporizadorGlobo = 0f;
    private float siguienteGlobo = 1f;

    // Limitador de globos
    public int globosPorOla = 20;
    private int cantidadGlobos = 1;

    // Temporizador de olas
    public float temporizadorOla = 30f;
    public float siguienteOla = 20f;

    // Temporizador de cuenta regresiva
    private float temporizadorCuentaRegresiva = 3f;
    private int healt;
    private int speed;

    // Inicio se llama antes del primer frame
    void Start()
    {
        
        // Comienza la cuenta regresiva
        StartCoroutine(IniciarCuentaRegresiva());
        
    }

    // Corutina de cuenta regresiva
    IEnumerator IniciarCuentaRegresiva()
    {
        while (temporizadorCuentaRegresiva > 0f)
        {
            yield return new WaitForSeconds(1f);
            temporizadorCuentaRegresiva--;
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        
        // Verifica si el temporizador de cuenta regresiva está en cero
        if (temporizadorCuentaRegresiva <= 0f)
        {
            // Lógica para enviar globos y crear olas después del temporizador
            if (temporizadorGlobo < Time.time && temporizadorOla < Time.time)
            {
                cantidadGlobos++;
                dificultad += aumentoDificultad;
                temporizadorGlobo = Time.time + siguienteGlobo;

                // Enviar globos aleatoriamente

                // Arreglo de globos disponibles
                GameObject[] prefabsGlobos = { globoAzul, globoVerde, globoRojo, globoAmarillo, globoRosa };

                // Seleccionar aleatoriamente un globo del arreglo
                int indiceAleatorio = UnityEngine.Random.Range(0, prefabsGlobos.Length);
                var prefabGloboSeleccionado = prefabsGlobos[indiceAleatorio];



                // Instanciar el globo seleccionado aleatoriamente
                var globo = Instantiate(prefabGloboSeleccionado, posicionInicial.position, prefabGloboSeleccionado.transform.rotation);
                
                // Obtener el componente Ballon adjunto al objeto globo
                var ballonComponent = globo.GetComponent<Ballon>();


                // Ajustar la salud y velocidad del globo según la dificultad
                if (globo != null)
                {
                    
                    // Aumento de dificultad
                    healt += Mathf.RoundToInt(dificultad);
                    speed += Mathf.RoundToInt(dificultad);

                    // Asignar las variables actualizadas al globo
                    // Verificar si el componente Ballon existe antes de acceder a sus propiedades
                    if (ballonComponent != null)
                    {
                        // Acceder a la propiedad healt del componente Ballon
                        healt = ballonComponent.healt;
                    }
                    else
                    {
                        // Manejar el caso en el que el componente Ballon no está adjunto al objeto globo
                        Debug.LogError("El objeto globo no tiene el componente Ballon adjunto.");
                    }


                    // Verificar si el componente Ballon existe antes de acceder a sus propiedades
                    if (ballonComponent != null)
                    {
                        // Acceder a la propiedad speed del componente Ballon
                        speed = ballonComponent.speed;
                    }
                    else
                    {
                        // Manejar el caso en el que el componente Ballon no está adjunto al objeto globo
                        Debug.LogError("El objeto globo no tiene el componente Ballon adjunto.");
                    }
                }
            }

            // Crear olas
            if (cantidadGlobos % globosPorOla == 0 && temporizadorOla < Time.time)
            {
                temporizadorOla = Time.time + siguienteOla;
            }
        }
    }
}
