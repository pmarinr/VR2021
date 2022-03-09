using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR2021.EquipoVerde
{
    public class SphereMenuController : MonoBehaviour
    {
        [SerializeField] GameObject menuContainer;

        private void OnTriggerEnter(Collider other)
        {
            FindObjectOfType<GameManager>().StartGame();

            menuContainer.SetActive(false);
        }
    }
}
