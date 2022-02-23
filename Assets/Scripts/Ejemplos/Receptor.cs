using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VR2021.Events;

namespace VR2021.demo
{
    public class Receptor : MonoBehaviour
    {
        // Start is called before the first frame update
        TextMeshProUGUI textoPuntos;
        int puntos = 0;
        void Start()
        {
            textoPuntos = GetComponent<TextMeshProUGUI>();
        }
        void OnEnable()
        {
            EventManager.StartListening("puntuar", OnPuntuar);
        }

      
        private void OnPuntuar(object obj)
        {
            puntos += (int)obj;
            textoPuntos.text = puntos.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}