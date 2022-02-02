using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoRojo
{
    public class ReturnBall : MonoBehaviour
    {
        private ScoreManager _score;
        private Vector3 _inicialPosition;
        private Rigidbody _rigidbody;
        [SerializeField] private GameObject _layerMask;

        void Start()
        {
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

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Pasa el trigger");
            if (other.gameObject.layer == _layerMask.gameObject.layer)
            {
                Debug.Log("Pasa la layer");
                ReturnOrigen();
                _score.AddPoints(1);
            }
        }
    }
}