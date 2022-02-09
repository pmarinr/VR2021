using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor { Red, Blue, Yellow, Green }

namespace VR2021.EquipoAzul
{
    public class PieceBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Material _clearMat, _myClearMat;

        [SerializeField] private PieceColor pieceColor;

        private int _points = 5;

        IEnumerator FadeObject()
        {
            yield return new WaitForSeconds(1.5f);
            GetComponent<MeshRenderer>().material = _myClearMat;

            for (float i = 0; i < 3f; i += Time.deltaTime)
            {
                GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, _clearMat.color, i);
                yield return new WaitForSeconds(.0001f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(FadeObject());
            PointsManager.instance.AddPoints(_points);
            gameObject.SetActive(false);
        }
    }
}