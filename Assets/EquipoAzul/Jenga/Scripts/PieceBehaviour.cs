using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PieceColor { Red, Blue, Yellow, Green }

namespace VR2021.EquipoAzul
{
    public class PieceBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Material _clearMat, _myClearMat;

        [SerializeField] private PieceColor pieceColor;

        private int _basePoints = 5;
        private int _totalPoints;

        public int numOfNeighbours;

        public bool _selected = false;
        private bool _deposited = false;

        [SerializeField] private List<Transform> _raycastPos;
        [SerializeField] private List<TMP_Text> _pointsTexts;

        private void Update()
        {
            if (!_selected)
            {
                _totalPoints = _basePoints + 2 * (10 - CheckNeighbourPieces());
            }

            foreach (TMP_Text pointText in _pointsTexts)
            {
                pointText.text = _totalPoints.ToString();
            }
        }

        public void SelectedPiece()
        {
            _selected = true;
        }

        private int CheckNeighbourPieces()
        {
            numOfNeighbours = 0;

            for (int i = 0; i < _raycastPos.Capacity; i++)
            {
                Debug.DrawLine(_raycastPos[i].position, _raycastPos[i].up * .05f + _raycastPos[i].position);
                if (Physics.Linecast(_raycastPos[i].position, _raycastPos[i].up * .05f + _raycastPos[i].position))
                {
                    numOfNeighbours++;
                }
            }

            return numOfNeighbours;
        }

        IEnumerator FadeObject()
        {
            yield return new WaitForSeconds(1.5f);
            GetComponent<MeshRenderer>().material = _myClearMat;

            for (float i = 0; i < 3f; i += Time.deltaTime)
            {
                GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, _clearMat.color, i/3);
                yield return new WaitForSeconds(.0001f);
            }

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_deposited)
            {
                StartCoroutine(FadeObject());

                if (other.CompareTag("Finish"))
                {
                    PointsManager.instance.GameOver();
                }
                else
                {
                    PointsManager.instance.AddPoints(_totalPoints, pieceColor);
                    _deposited = true;
                }
            }
        }
    }
}