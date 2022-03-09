using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesManager : MonoBehaviour
{
    private NextHole _nextHole;
    public bool _completed;

    void Start()
    {
        _nextHole = FindObjectOfType<NextHole>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            print("BallIN");
            _nextHole._completedHole = true;
        }
    }

    
}
