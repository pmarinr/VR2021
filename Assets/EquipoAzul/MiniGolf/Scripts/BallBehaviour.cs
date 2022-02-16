using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Transform _hitLeft;
    [SerializeField] private Transform _hitRight;
    [SerializeField] private ClubBehaviour _club;
    [SerializeField] private float _force;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _club = FindObjectOfType<ClubBehaviour>();
    }

    private void Update()
    {
        _force = 30 * _club.rb.velocity.magnitude;
        print(_force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Club"))
        {
            //_rb.AddForce(_club.transform.position, ForceMode.Impulse);
        }

        if (collision.collider.CompareTag("ClubLeft"))
        {
            _rb.AddForce(_hitLeft.up * _force, ForceMode.Impulse);
        }
        if (collision.collider.CompareTag("ClubRight"))
        {
            _rb.AddForce(_hitRight.up * _force, ForceMode.Impulse);
        }
    }
}
