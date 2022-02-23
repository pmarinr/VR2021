using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class TargetCollisionController : MonoBehaviour
    {
        [SerializeField] private int pointValue = 1;

        TargetController targetController;

        private void Awake()
        {
            targetController = GetComponentInParent<TargetController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Bullet")
            {
                targetController.Score(pointValue);
            }
        }
    }
}
