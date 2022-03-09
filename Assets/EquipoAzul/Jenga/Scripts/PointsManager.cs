using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public static int yellowPieces;
    public static int greenPieces;
    public static int bluePieces;
    public static int redPieces;

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

    public void AddPoints(int points, PieceColor color)
    {
        _points += points;
        _pointsText.text = $"Puntos: {_points}";

        switch (color)
        {
            case PieceColor.Yellow:
                yellowPieces++;

                if (yellowPieces % 3 == 0)
                    YellowEffect();

                break;

            case PieceColor.Green:
                greenPieces++;

                if (greenPieces % 3 == 0)
                    GreenEffect();

                break;

            case PieceColor.Blue:
                bluePieces++;

                if (bluePieces % 3 == 0)
                    BlueEffect();

                break;

            case PieceColor.Red:
                redPieces++;

                if (redPieces % 3 == 0)
                    RedEffect();

                break;
        }
    }

    private void YellowEffect()
    {
        print("Mano Izq");
    }

    private void GreenEffect()
    {
        print("Mano Der");
    }

    private void BlueEffect()
    {
        print("Pelotas");
    }

    private void RedEffect()
    {
        print("Viento");
    }

    public void GameOver()
    {
        print("Cagaste");
    }
}