using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoAzul
{
    public class PieceBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Material _clearMat;
        private Material _myMat;

        private void Start()
        {
            _myMat = GetComponent<MeshRenderer>().material;
        }

        IEnumerator FadeTime()
        {
            yield return new WaitForSeconds(1.5f);

            for (float i = 0; i < 2f; i += Time.deltaTime)
            {
                _myMat.color = Color.Lerp(_myMat.color, _clearMat.color, i);
                yield return new WaitForSeconds(.0001f); ;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(FadeTime());
        }
    }
}