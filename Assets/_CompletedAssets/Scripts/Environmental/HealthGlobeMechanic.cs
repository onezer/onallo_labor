using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompleteProject
{
    public class HealthGlobeMechanic : MonoBehaviour
    {

        public int HealingAmount;
        public float CoolDown;

        float timer;
        bool onCD;
        MeshRenderer meshRenderer;
        GameObject Player;
        public bool playerIn;

        void Awake()
        {
            timer = 0;
            meshRenderer = GetComponent<MeshRenderer>();
            Player = GameObject.FindGameObjectWithTag("Player");
            onCD = false;
        }


        void HealPlayer()
        {
            onCD = true;
            Player.gameObject.GetComponent<PlayerHealth>().TakeHealing(HealingAmount);
            meshRenderer.enabled = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {
                playerIn = true;
                if (!onCD)
                {
                    HealPlayer();
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.gameObject == Player)
            {
                playerIn = false;
            }
        } 

        void Update()
        {

            if (onCD)
            {
                timer += Time.deltaTime;
            }
            else if(playerIn)
            {
                HealPlayer();
            }

            if (timer >= CoolDown)
            {
                timer = 0;
                meshRenderer.enabled = true;
                onCD = false;
            }

        }
    }
}