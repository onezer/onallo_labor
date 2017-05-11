using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class SlowTrapMechanics : MonoBehaviour
    {
        public float SlowPercent;
        public float SlowDuration;

        public float LifeSpan;

        Vector3 scale;

        public Material ActiveMaterial;
        public Material InactiveMaterial;

        Renderer rend;

        float timer = 0;

        bool activated = false;

        void Awake()
        {
            rend = GetComponent<Renderer>();
            scale = transform.localScale / 2;
            scale.y = 5;
            rend.material = InactiveMaterial;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger == false)
            {
                if (other.gameObject.tag == "Enemy")
                {
                    activated = true;

                }
            }
        }

        void OnTriggerExit(Collider other)
        {


        }

        void LifeSpanManager()
        {
            if (activated)
            {
                timer += Time.deltaTime;
            }

            if (timer >= LifeSpan)
            {
                Destroy(gameObject);
            }
        }

        void SlowTargets(Collider[] Targets)
        {
            for (int i = 0; i < Targets.Length; i++)
            {
                if (Targets[i].GetComponent<EnemyMain>() != null)
                {
                    Targets[i].GetComponent<EnemyMain>().Slow(SlowPercent,SlowDuration);
                }
            }
        }

        void Update()
        {
            LifeSpanManager();

            if(activated)
            {
                Collider[] targets = Physics.OverlapBox(transform.position, scale);

                rend.material = ActiveMaterial;

                SlowTargets(targets);
            }

        }
    }
}