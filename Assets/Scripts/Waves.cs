using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Waves : MonoBehaviour
{
    public float difficulty = 0.4f;
    public float difficultyIncreaseSpeed = 0.01f;
    public Transform startPosition;
    public GameObject ballonGreen;
    public GameObject ballonBlue;
    public GameObject ballonRed;
    public GameObject ballonYellow;
    public GameObject ballonPink;

    //Timer
    private float ballonTimer = 0f;
    private float nextBallon = 1f;

    //Ballon Limiter
    public int ballonsPerWave = 20;
    private int ballonsCount = 1;

    //waves Timer
    public float waveTimer = 30f;
    public float nextWave = 20f;

    // Countdown Timer
    private float countdownTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Begin de countdown
        StartCoroutine(StartCountdown());
    }
    // Countdown Coroutine
    IEnumerator StartCountdown()
    {
        while (countdownTimer > 0f)
        {
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }
    }
    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        // Verifica si el contador está en cero
        if (countdownTimer <= 0f)
        {
            // Lógica para enviar globos y crear olas después del contador
            if (ballonTimer < Time.time && waveTimer < Time.time)
            {
                ballonsCount++;
                difficulty += difficultyIncreaseSpeed;
                ballonTimer = Time.time + nextBallon;

                // Send Ballons Randomly

                // Available balloons prefabs array
                GameObject[] balloonPrefabs = { ballonBlue, ballonGreen, ballonRed, ballonYellow, ballonPink };

                // Randomly select a prefab from ballon Array
                int randomIndex = UnityEngine.Random.Range(0, balloonPrefabs.Length);
                var selectedBalloonPrefab = balloonPrefabs[randomIndex];

                // Instantance the randomly selected balloon
                var balloon = Instantiate(selectedBalloonPrefab, startPosition.position, selectedBalloonPrefab.transform.rotation);

                // Adjust the health and speed of the balloon based on the difficulty
                balloon.GetComponent<Ballon>().healt += (int)Math.Round(difficulty);
                balloon.GetComponent<Ballon>().speed += (int)Math.Round(difficulty);
            }

            // Create Waves
            if (ballonsCount % ballonsPerWave == 0 && waveTimer < Time.time)
            {
                waveTimer = Time.time + nextWave;
            }
        }
    }
}
