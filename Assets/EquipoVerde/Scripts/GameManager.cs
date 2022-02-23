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

        public void AddScore(int points)
        {
            score += points;

            scoreText.text = score.ToString();
        }
    }
}
