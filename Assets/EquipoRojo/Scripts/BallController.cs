using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoRojo
{
    public class BallController : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        private Vector3 _inicialPosition;
        private Rigidbody _rigidbody;
        //[SerializeField] private GameObject _layerMask;

        public bool hitTable;
        public int tableHits;
        public int tableHitsNecesarios;

        void Start()
        {
            tableHits = 0;
            _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
            _inicialPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void ReturnOrigen()
        {
            transform.position = _inicialPosition;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.transform.Rotate(Vector3.zero);
        }

        void Update()
        {
            if (transform.position.y < -0.9f)
            {
                ReturnOrigen();
            }
        }

       /* private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Pasa el trigger");
            if (other.gameObject.layer == _layerMask.gameObject.layer)
            {
                Debug.Log("Pasa la layer");
                

            }
        }*/


        private void OnCollisionEnter(Collision col)
        {

            if (col.gameObject.CompareTag("EquipoRojo_TableHit"))
            {
                tableHits++;
                if(tableHits == tableHitsNecesarios)
                {
                    hitTable = true;
                }
                
            }

            if (col.gameObject.CompareTag("EquipoRojoVaso50"))
            {
                if (hitTable == true)
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue*2);
                    ReturnOrigen();
                }
                else
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue);
                    ReturnOrigen();
                }
            }

            if (col.gameObject.CompareTag("EquipoRojoVaso100"))
            {
                if (hitTable == true)
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 4);
                    ReturnOrigen();
                }
                else
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 2);
                    ReturnOrigen();
                }
            }

            if (col.gameObject.CompareTag("EquipoRojoVaso150"))
            {
                if (hitTable == true)
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 6);
                    ReturnOrigen();
                }
                else
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 3);
                    ReturnOrigen();
                }
            }

            if (col.gameObject.CompareTag("EquipoRojoVaso200"))
            {
                if (hitTable == true)
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 8);
                    ReturnOrigen();
                }
                else
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 4);
                    ReturnOrigen();
                }
            }

            if (col.gameObject.CompareTag("EquipoRojoVaso300"))
            {
                if (hitTable == true)
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 12);
                    ReturnOrigen();
                }
                else
                {
                    _scoreManager.AddPoints(_scoreManager.pointValue * 6);
                    ReturnOrigen();
                }
            }
        }
    }
}