using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    [SerializeField] private int _points;
    [SerializeField] private TMP_Text _pointsText;

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

    public void AddPoints(int points)
    {
        _points += points;
        _pointsText.text = $"Puntos: {_points}";
    }
}