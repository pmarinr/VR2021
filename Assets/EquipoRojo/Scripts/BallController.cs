using System;
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
        [SerializeField] private GameObject _layerMask;

        public bool hitTable;
        public int tableHits;
        public int tableHitsNecesarios;

        public AudioManager aM;

        private float timeToResetOrigenTableGlass;



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
            transform.Rotate(Vector3.zero);
            GetComponent<Collider>().material.bounciness = 0.85f;
        }

        void Update()
        {
            
            if (transform.position.y < -0.9f)
            {
                ReturnOrigen();
            }

            
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("EquipoRojoTableGlass"))
            {
                timeToResetOrigenTableGlass += Time.deltaTime;
                if (timeToResetOrigenTableGlass > 3)
                {
                    ReturnOrigen();
                    timeToResetOrigenTableGlass = 0;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.tag.Contains("EquipoRojoVaso") || other.transform.CompareTag("EquipoRojo_TableHit"))
            {
                Puntua(other.gameObject);
                
            }

            if (other.transform.tag.Contains("EquipoRojoVaso"))
            {
                GetComponent<Collider>().material.bounciness = 0f;

                aM.GlassHit();

            }
            

        }
        private void OnCollisionEnter(Collision collision)
        {
            aM.TableHit();
        }



        private void Puntua(GameObject gameObject)
        {

            aM.Point();
            


            int points = 0;
            if (gameObject.CompareTag("EquipoRojo_TableHit"))
            {

                tableHits++;
                if (tableHits == tableHitsNecesarios)
                {
                    hitTable = true;
                }

            }


            if (gameObject.CompareTag("EquipoRojoVaso50"))   points = _scoreManager.pointValue;
            if (gameObject.CompareTag("EquipoRojoVaso100")) points = _scoreManager.pointValue * 2;
            if (gameObject.CompareTag("EquipoRojoVaso150")) points = _scoreManager.pointValue * 3;
            if (gameObject.CompareTag("EquipoRojoVaso200")) points = _scoreManager.pointValue * 4;
            if (gameObject.CompareTag("EquipoRojoVaso300")) points = _scoreManager.pointValue * 6;

            if (hitTable == true) points = points * 2;
            _scoreManager.AddPoints(points);
            Invoke("ReturnOrigen", 2);
        }
    }
}