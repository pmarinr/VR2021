using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR2021.Events;

namespace VR2021
{
    public class ReceptorCubo2 : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.StartListening("activar_cubos", OnActivate);
        }

        private void OnActivate(object obj)
        {
            transform.localScale = Vector3.one;
        }

       
    }
}