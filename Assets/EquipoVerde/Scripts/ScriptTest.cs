using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR2021.EquipoAzul;

namespace VR2021.EquipoVerde
{
    public class ScriptTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
         
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            print(transform.name);
        }
    }
}