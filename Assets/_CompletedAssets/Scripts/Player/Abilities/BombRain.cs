using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class BombRain : MonoBehaviour
    {
        public int BombNumber;
        public float TimeBetweenBombs;
        public float Radius;
        public int Damage;
        public float ExplosionRange;

        public GameObject Bomb;

        float timer = 0;

        void Awake()
        {
            transform.localScale = new Vector3(Radius,Radius,1);
        }

        Vector3 RandomPosition()
        {
            float rx;
            float rz;

            rx = Random.Range(-Radius, Radius);
            rz = Random.Range(-Mathf.Sqrt(Radius * Radius - rx * rx), Mathf.Sqrt(Radius * Radius - rx * rx));

            return new Vector3(rx + transform.position.x, 8, rz + transform.position.z);
        }
        
        void Update()
        {

            if (timer >= TimeBetweenBombs && BombNumber > 0)
            {
                Bomb = Instantiate(Bomb);
                Bomb.transform.position = RandomPosition();
                Bomb.GetComponent<BombMechanics>().range = ExplosionRange;
                Bomb.GetComponent<BombMechanics>().damage = Damage;

                BombNumber--;
                timer = 0;
            }
            timer += Time.deltaTime;

            if(BombNumber == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}