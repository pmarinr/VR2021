using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private Rigidbody _hitRB;
    [SerializeField] private Transform _hitPos;
    [SerializeField] private Transform _hitDir;
    [SerializeField] private GameObject _club;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _hitRB.transform.position = _hitPos.transform.position;
        _hitRB.rotation = _hitPos.rotation;
        _hitDir.transform.position = _hitPos.transform.position;
        _hitDir.rotation = _hitPos.rotation;
    }
}
