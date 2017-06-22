using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class BombMechanics : MonoBehaviour {
        public float range;
        public int damage;

        float timer = 0;

        bool exploded = false;

        public GameObject explosion;
        GameObject Player;
        GameObject[] Enemies;

        Collider sphCollider;

        Vector3 explosionScale = new Vector3(1f, 1f, 1f);
        Vector3 scaling = new Vector3(0.8f, 0.8f, 0.8f);

        bool Animating = false;

        List<MainModule> modules;  //Containing player and enemy mainmodules


        void Awake() {
            explosion.transform.localScale = new Vector3(0f, 0f, 0f);
            explosion.GetComponent<MeshRenderer>().enabled = false;

            sphCollider = GetComponent<SphereCollider>();


        }


        void Animate()
        {
            Animating = true;
            explosion.GetComponent<MeshRenderer>().enabled = true;
        }

        void Explode()
        {
            exploded = true;

            modules = new List<MainModule>();
            Player = GameObject.FindGameObjectWithTag("Player");
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            modules.Add(Player.GetComponent<MainModule>());

            foreach (GameObject e in Enemies)
            {
                modules.Add(e.GetComponent<MainModule>());
            }

            foreach (MainModule m in modules)
            {
                if (Vector3.Distance(m.GetPosition(), transform.position) <= range)
                {
                    m.TakeDamage(damage);
                }
            }

            GetComponent<Rigidbody>().drag = 100000;

            Animate();

            GameObject.Destroy(gameObject,0.5f);

        }

        void OnCollisionEnter()
        {
            Explode();
        }

        void Update() {
        
            if(Animating)
            {

                explosionScale = explosionScale + scaling;
                explosion.transform.localScale = explosionScale;

                if (explosion.transform.lossyScale.x >= range)
                {
                    Animating = false;
                }
            }

            timer += Time.deltaTime;

            if(timer >= 0.6f && sphCollider.enabled == false)
            {
                sphCollider.enabled = true;
            }

            if(timer >= 5)
            {
                Explode();
            }

        }
    }
}