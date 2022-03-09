using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class TargetSpawnController : MonoBehaviour
    {
        [SerializeField] GameObject targetPrefab;

        [SerializeField] Vector2 lifetimeRange;

        [SerializeField] Vector2 timeBetweenTargets;

        void Start()
        {
            StartCoroutine(SpawnTargetCT());
        }

        IEnumerator SpawnTargetCT()
        {
            yield return new WaitForSeconds(Random.Range(timeBetweenTargets.x, timeBetweenTargets.y));

            GameObject instantiatedTarget = Instantiate(targetPrefab, new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(1.2f, 1.8f), Random.Range(2.2f, 3.4f)), targetPrefab.transform.rotation, transform);

            yield return new WaitForSeconds(Random.Range(lifetimeRange.x, lifetimeRange.y));

            instantiatedTarget.GetComponent<Animator>().SetTrigger("GoUp");

            yield return new WaitForSeconds(1f);

            Destroy(instantiatedTarget);

            StartCoroutine(SpawnTargetCT());
        }
    }
}
