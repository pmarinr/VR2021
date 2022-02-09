using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR2021
{
    public class ChangeMaterialOnCollision : MonoBehaviour
    {
        public Material materialSeleccion;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<MeshCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<MeshRenderer>().material = materialSeleccion;
            }
        }
    }
}
