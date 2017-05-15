using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Trap : MonoBehaviour {

        public int Damage;
        public float EffectTime;
        public float TimeBetweenDamage;

        Vector3 scale;

        float timer;
        Material material;


        void Awake()
        {
            material = GetComponent<Renderer>().material;
            timer = 0f;
            scale = transform.localScale / 2;
            scale.y = 5;
        }

        void TrapDamage(Collider[] Targets)
        {
            if (Targets == null)
                return;


            material.SetColor("_EmissionColor", Color.red);

            

            for (int i = 0; i < Targets.Length; i++)
            {
                if (Targets[i].GetComponent<MainModule>() != null)
                {
                    Targets[i].GetComponent<MainModule>().TakeDamage(Damage);
                }
            }
        }


        void Update()
        {
            timer += Time.deltaTime;
            Collider[] hitColliders = Physics.OverlapBox(transform.position, scale);

            if(timer >= TimeBetweenDamage)
            {
                timer = 0f;
                TrapDamage(hitColliders);
            }

            if(timer >= EffectTime)
            {
                material.SetColor("_EmissionColor", Color.black);
            }       
        }
    }
}