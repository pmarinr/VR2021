using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private GameObject _club;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Club"))
        {
            _rb.AddForce(_club.transform.position, ForceMode.Impulse);
        }
    }
}
