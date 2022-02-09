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
            bulletRigidbody.AddForce(0, bulletForce, 0);
        }

        void Update()
        {

        }
    }
}
