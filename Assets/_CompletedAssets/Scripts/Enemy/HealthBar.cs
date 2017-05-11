using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class HealthBar : MonoBehaviour
    {

        public Material EnragedMaterial;
        public Material NormalMaterial;

        MeshRenderer render;

        EnemyMain main;

        public float HPPercent;


        void Awake()
        {
            render = GetComponent<MeshRenderer>();
            main = GetComponentInParent<EnemyMain>();
        }


        void Update()
        {
            if(main.isEnraged)
            {
                render.material = EnragedMaterial;
            }
            else
            {
                render.material = NormalMaterial;
            }

            transform.localScale = new Vector3(1.5f * HPPercent, 0.1f, 1f);
 
            transform.rotation = Quaternion.identity;

        }
    }
}