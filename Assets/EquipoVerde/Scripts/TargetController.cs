using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class TargetController : MonoBehaviour
    {
        MeshCollider[] childrenMeshColliders;

        public bool changeSize = false;

        [SerializeField] Vector2 sizeRange;

        public void Score(int points)
        {
            //childrenMeshColliders = GetComponentsInChildren<MeshCollider>();

            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    childrenMeshColliders[i].enabled = false;
            //}

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
