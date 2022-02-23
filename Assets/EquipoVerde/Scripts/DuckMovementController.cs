using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class DuckMovementController : MonoBehaviour
    {
        [SerializeField] Vector2 speedRange;

        private float speed;

        void Start()
        {
            speed = Random.Range(speedRange.x, speedRange.y);
        }

        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag == "DuckRemover")
            {
                Destroy(gameObject);
            }
        }
    }
}
