using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace VR2021.EquipoVerde
{
    public class PistolController : MonoBehaviour
    {
        [SerializeField] private Animator pistolAnimator;

        [SerializeField] private Transform pistolNozzle;

        [SerializeField] private GameObject bullet;

        private float triggerValue = 0f;

        void Start()
        {
        
        }

        void Update()
        {
            
        }

        void Shoot()
        {
            Instantiate(bullet, pistolNozzle);
        }

        public void ControllerRightTrigger(InputAction.CallbackContext ctx)
        {
            triggerValue = ctx.ReadValue<float>();

            triggerValue = Mathf.Round(triggerValue * 100f) / 100f;

            pistolAnimator.SetFloat("TriggerPull", triggerValue);

            if (ctx.started)
            {
                Shoot();
            }
        }
    }
}
