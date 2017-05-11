
using UnityEngine;

namespace CompleteProject
{
    public class StunBallMove : MonoBehaviour {

        public float Radius;
        public int Speed;
        public float Movspeed;
        public float Height;
        public float LifeSpan;

        public Vector3 Direction;

        GameObject player;
        float timer = 0;
        float timer2 = 0;

        Vector3 newPos;

        Vector3 directpos;

        void Awake ()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            directpos = player.transform.position;
        }

        
        void Update() {
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;

            directpos += Direction * Time.deltaTime * Movspeed;

            newPos.x = Radius * Mathf.Sin(timer * Speed) + directpos.x;
            newPos.z = Radius * Mathf.Cos(timer * Speed) + directpos.z;
            newPos.y = Height;

            transform.position = newPos;

            timer = timer % (2 * Mathf.PI);

            if(timer2 >= LifeSpan)
            {
                Destroy(gameObject);
            }
        }
    }
}