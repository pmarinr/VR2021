using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class DuckSpawnController : MonoBehaviour
    {
        [SerializeField] GameObject duckPrefab;

        [SerializeField] Vector2 timeBetweenDucks;

        void Start()
        {
            StartCoroutine(SpawnDuck());
        }

        IEnumerator SpawnDuck()
        {
            yield return new WaitForSeconds(Random.Range(timeBetweenDucks.x, timeBetweenDucks.y));

            Instantiate(duckPrefab, new Vector3(1.6f, 0.721f, Random.Range(1.48f, 1.9f)), duckPrefab.transform.rotation, transform);

            StartCoroutine(SpawnDuck());
        }
    }
}
