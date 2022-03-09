using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class TargetController : MonoBehaviour
    {
        public bool changeSize = false;

        [SerializeField] Vector2 sizeRange;

        public void Score(int points)
        {
            FindObjectOfType<GameManager>().AddScore(points);
        }

        private void Start()
        {
            if (changeSize)
            {
                float newScale = Random.Range(sizeRange.x, sizeRange.y);
                transform.localScale = new Vector3(newScale, newScale, newScale);
            }
        }
    }
}
