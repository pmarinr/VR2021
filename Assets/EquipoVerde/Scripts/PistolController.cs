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

        [SerializeField] private Transform bulletParent;

        [SerializeField] private GameObject bullet;

        [SerializeField] private float shootingCadence = 0.1f;

        private float triggerValue = 0f;

        bool canShoot = true;

        void Start()
        {
        
        }

        void Update()
        {
            
        }

        void Shoot()
        {
            Instantiate(bullet, pistolNozzle.position, pistolNozzle.rotation, bulletParent);

            canShoot = false;

            //StartCoroutine(ShootCooldown());
        }

        public void ControllerRightTrigger(InputAction.CallbackContext ctx)
        {
            triggerValue = ctx.ReadValue<float>();

            triggerValue = Mathf.Round(triggerValue * 100f) / 100f;

            pistolAnimator.SetFloat("TriggerPull", triggerValue);

            if (ctx.ReadValue<float>() >= 0.85f)
            {
                if (canShoot)
                {
                    Shoot();
                }
            }

            if(ctx.ReadValue<float>() <= 0.15f)
            {
                canShoot = true;
            }
        }

        IEnumerator ShootCooldown()
        {
            yield return new WaitForSeconds(shootingCadence);

            canShoot = true;
        }
    }
}
