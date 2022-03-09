using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VR2021
{
    public class ScoreRow : MonoBehaviour
    {
        public TextMeshProUGUI player;
        public TextMeshProUGUI points;

        public void Setup(Score score)
        {
            player.text = score.player;
            points.text = score.score.ToString();

        }

    }

    
}
