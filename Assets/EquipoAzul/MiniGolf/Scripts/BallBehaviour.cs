using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Rigidbody _hitRB;
    [SerializeField] private ClubBehaviour _club;
    [SerializeField] private BallDistance _clubRB;
    private float _force;
    [SerializeField] private float _extraForce;

    [SerializeField] private Transform _hitDir;

    private bool _grounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _club = FindObjectOfType<ClubBehaviour>();
        _clubRB = FindObjectOfType<BallDistance>();

    }

    private void FixedUpdate()
    {
        if(_rb.velocity.magnitude < 0.22f && _grounded)
        {
            _rb.velocity = Vector3.zero;
        }

        if(Physics.CheckSphere(transform.position, 0.06f))
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }

    private void Update()
    {
        //_force = _extraForce * _club.rb.velocity.magnitude;     //Fuerza de velocidad del palo + extra
    }

    public void HitBall()
    {
        //_rb.AddForce(_hitDir.transform.up * _force, ForceMode.Impulse);
        _rb.AddForce(-_clubRB._direction * /*_hitRB.velocity.magnitude **/  _extraForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Club"))
        //{
        //    Debug.Log("hit");
        //    _rb.AddForce(_hitDir.transform.up * _force, ForceMode.Impulse);
        //}

        //if (collision.collider.CompareTag("ClubLeft"))
        //{
        //    _rb.AddForce(_hitLeft.up * _force, ForceMode.Impulse);
        //}
        //if (collision.collider.CompareTag("ClubRight"))
        //{
        //    _rb.AddForce(_hitRight.up * _force, ForceMode.Impulse);
        //}
    }
}
