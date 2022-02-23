using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR2021.Events;
namespace VR2021
{
    public class ReceptorCubo1 : MonoBehaviour
    {

        private void OnEnable()
        {
            EventManager.StartListening("puntuar", OnPuntuarCrecer);
            
        }

        private void OnPuntuarCrecer(object obj)
        {
            int tam = (int)obj;
            transform.localScale = transform.localScale * tam;
        }

       


    }
}