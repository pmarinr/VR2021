using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VR2021.EquipoVerde
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;      //Almacena la puntuación de la partida

        bool gameEnded = true;

        [SerializeField] private int secondsToPlay = 120;

        float timeLeft;

        [SerializeField] private TextMeshProUGUI timerText;

        [SerializeField] GameObject targetSpawner;
        [SerializeField] GameObject duckSpawner;

        [SerializeField] GameObject endCanvas;

        private void Start()
        {
            timeLeft = secondsToPlay;
        }

        private void Update()
        {
            if (!gameEnded)
            {
                UpdateTimer();
            }
        }

        //Actualiza la puntuación
        public void AddScore(int points)
        {
            if (!gameEnded)
            {
                score += points;

                scoreText.text = score.ToString();
            }
        }

        public void StartGame()
        {
            gameEnded = false;

            targetSpawner.SetActive(true);
            duckSpawner.SetActive(true);
        }

        void EndGame()
        {
            gameEnded = true;

            targetSpawner.SetActive(false);
            duckSpawner.SetActive(false);

            endCanvas.SetActive(true);
        }

        void UpdateTimer()
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }

            if (timeLeft < 0)
            {
                timeLeft = 0;

                EndGame();
            }

            int timeInInt = (int)timeLeft;
            timerText.text = timeInInt.ToString();
        }
    }
}
