using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoRojo
{
    public class GlassController : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
       
        IEnumerator CollisionPlayer()
        {
            _audioManager.BallIn();
            yield return new WaitForSeconds(1);
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        public Material materialSeleccion;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<MeshRenderer>().material = materialSeleccion;
                StartCoroutine(CollisionPlayer());
                
            }
        }
    }
}
