using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private Rigidbody _hitRB;
    [SerializeField] private Transform _hitPos;
    [SerializeField] private GameObject _club;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _hitRB.transform.position = _hitPos.transform.position;
        _hitRB.rotation = _hitPos.rotation;
    }
}
