using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    [SerializeField] private int _points;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        _points = 0;
    }

    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        _points += points;
    }
}