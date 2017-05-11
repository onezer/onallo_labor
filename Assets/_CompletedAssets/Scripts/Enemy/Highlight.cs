using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Highlight : MonoBehaviour
    {
        public bool HighLighted;

        public GameObject highobj;

        public MeshRenderer rend;

        void Awake()
        {
            //highobj = GameObject.FindGameObjectWithTag("Highobj");
        }


        void Update()
        {

            if(HighLighted)
            {
                //rend.enabled = true;
            }
            else
            {
                //rend.enabled = false;
            }

        }
    }
}