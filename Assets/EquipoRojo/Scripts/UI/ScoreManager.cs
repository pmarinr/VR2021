using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace VR2021.EquipoRojo
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI currentscoreText;
        public TextMeshProUGUI highScoreText;
        public int pointValue = 50;
        private int _currentScorePoints;

        private void Start()
        {
            _currentScorePoints = 0;
            currentscoreText.text = "Score: " + "00";
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 00).ToString();

        }
        
        public void AddPoints(int points)
        {
            highScoreText.enabled = false;
            _currentScorePoints += points;
            int number = _currentScorePoints;
            currentscoreText.text = "Score: " + _currentScorePoints.ToString("00");

            if (number > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", number);
                highScoreText.text = "HighScore: " + number.ToString();
            }
            
        }

        public void ResetScore()
        {
            PlayerPrefs.DeleteAll();
            _currentScorePoints = 0;
            highScoreText.text = "HighScore: " + "00";
            currentscoreText.text = "Score: " + "00";
            highScoreText.enabled = true;
        }

        public void Lost()
        {
            _currentScorePoints = 0;
            highScoreText.enabled = true;
        }

    }
}

