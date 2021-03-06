using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoAzul
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _pieces = new List<GameObject>();

        [SerializeField]
        private Vector3 _tableOrigin;
        
        [SerializeField]
        private int _rows;

        private const float _pieceHeight = .105f;
        private const float _pieceWidth = .205f;

        private void Start()
        {
            for (int pieceNumber = 0; pieceNumber < 3; pieceNumber++)
            {
                for (int row = 0; row < _rows; row++)
                {
                    bool isRotated = false;
                    if (row % 2 == 1) { isRotated = true; }

                    GameObject piece = _pieces[Random.Range(0, _pieces.Count)];

                    if (isRotated)
                    {
                        Instantiate(piece, NextPiecePosition(pieceNumber, row) + _tableOrigin, Quaternion.identity, transform.GetChild(0));
                    }
                    else
                    {
                        Instantiate(piece, NextPiecePosition(pieceNumber, row) + _tableOrigin, Quaternion.Euler(Vector3.up * 90), transform.GetChild(0));
                    }
                }
            }
        }

        private Vector3 NextPiecePosition(int pieceNumber, int row)
        {
            Vector3 nextPiecePos;

            bool isRotated = false;
            if (row % 2 == 1) { isRotated = true; }

            if (isRotated)
            {
                float xPos = pieceNumber * _pieceWidth - _pieceWidth;
                float yPos = row * _pieceHeight + _pieceHeight / 2;

                nextPiecePos = new Vector3(xPos, yPos, 0);
            }
            else
            {
                float zPos = pieceNumber * _pieceWidth - _pieceWidth;
                float yPos = row * _pieceHeight + _pieceHeight / 2;

                nextPiecePos = new Vector3(0, yPos, zPos);
            }


            return nextPiecePos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(_tableOrigin, .05f);
        }
    }
}