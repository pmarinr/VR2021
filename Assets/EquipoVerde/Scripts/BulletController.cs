using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float bulletForce = 5f;

        private Rigidbody bulletRigidbody;

        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            bulletRigidbody.AddRelativeForce(new Vector3(0, 0, bulletForce), ForceMode.Impulse);
        }

        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            bulletRigidbody.velocity = Vector3.zero;

            bulletRigidbody.isKinematic = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
