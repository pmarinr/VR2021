using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VR2021.EquipoRojo
{
    public class Cronometer : MonoBehaviour
    {
        public TextMeshProUGUI time;
        public float totalTime;

        void Update()
        {
            totalTime -= Time.deltaTime;
            time.text = "Time: " + Mathf.Floor(totalTime).ToString("00");
           
            /*if (totalTime = 0)
            {
                SceneManager.LoadScene
            }*/
        }
    }
}