using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VR2021.EquipoVerde
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;

        public bool gameEnded = true;

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

        public void AddScore(int points)
        {
            if (!gameEnded)
            {
                score += points;

                scoreText.text = score.ToString();
            }
        }

        private void Update()
        {
            if (!gameEnded)
            {
                UpdateTimer();
            }
        }

        public void StartGame()
        {
            gameEnded = false;

            targetSpawner.SetActive(true);
            duckSpawner.SetActive(true);
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

                gameEnded = true;

                targetSpawner.SetActive(false);
                duckSpawner.SetActive(false);

                endCanvas.SetActive(true);
            }

            int timeInInt = (int)timeLeft;
            timerText.text = timeInInt.ToString();
        }
    }
}
