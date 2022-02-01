using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR2021.Events;

namespace VR2021.demo
{
    public class Emisor : MonoBehaviour
    {
        // Start is called before the first frame update
        public void puntuar(int puntos)
        {
            Debug.Log("puntuar");
            EventManager.TriggerEvent("puntuar", puntos);
        }
    }
}
