using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float bulletForce = 5f;

        private Rigidbody bulletRigidbody;

        [SerializeField] AudioSource audioSource;

        [SerializeField] AudioClip shootSound;

        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            bulletRigidbody.AddRelativeForce(new Vector3(0, 0, bulletForce), ForceMode.Impulse);

            StartCoroutine(DestroyGameobject());
        }

        private void OnCollisionEnter(Collision collision)
        {
            bulletRigidbody.velocity = Vector3.zero;

            transform.parent = collision.transform;

            bulletRigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            bulletRigidbody.isKinematic = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            audioSource.PlayOneShot(shootSound);
        }

        IEnumerator DestroyGameobject()
        {
            yield return new WaitForSeconds(10f);

            Destroy(gameObject);
        }
    }
}
