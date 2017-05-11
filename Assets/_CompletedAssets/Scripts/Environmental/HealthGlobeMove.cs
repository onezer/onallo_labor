using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class HealthGlobeMove : MonoBehaviour
    {

        public float Height;
        public int FloatingSpeed;
        public float Amplitude;


        float timer;
        Vector3 newPos;

        void Awake()
        {
            timer = 0f;
            newPos = transform.position;
        }



        void Update()
        {
            timer += Time.deltaTime;

            newPos.y = Mathf.Sin(timer * FloatingSpeed) * Amplitude + Height;
            transform.position = newPos;

            timer = timer % (2 * Mathf.PI);
        }
    }
}