using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDistance : MonoBehaviour
{

    [SerializeField] private BallBehaviour _ball;
    private Vector3 _ballPos;
    private float _distance;
    public Vector3 _direction;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _ballPos = _ball.transform.position;
        _distance = Vector3.Distance(transform.position, _ballPos);
        _direction = transform.position - _ball.transform.position;
        print("DISTANCE: " + _distance);

        if (_distance < 0.2f)
        {
            _ball.HitBall();
        }
    }

    void Update()
    {
        
    }
}
