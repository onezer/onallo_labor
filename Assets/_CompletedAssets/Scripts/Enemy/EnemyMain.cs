using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class EnemyMain : MonoBehaviour, MainModule
    {
        EnemyHealth HP;
        EnemyMovement MOV;

        void Awake()
        {
            HP = GetComponent<EnemyHealth>();
            MOV = GetComponent<EnemyMovement>();
        }

        public bool isEnraged
        {
            get
            {
                return MOV.isEnraged;
            }

            set
            {
                MOV.isEnraged = value;
            }
        }


        public int GetHealth()
        {
            return HP.currentHealth;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void TakeHealing(int Heal)
        {
            HP.TakeHealing(Heal);
        }

        public void Stun(float Time)
        {
            MOV.Stun(Time);
        }

        public void Slow(float Percent, float Duration)
        {
            MOV.Slow(Percent, Duration);
        }

        public Vector3 GetMovement()
        {
            return MOV.GetMovement();
        }

        public void TakeDamage(int Damage)
        {
            HP.TakeNormalDamage(Damage);
        }

        public void TakeDamageWithEffect(int Damage, Vector3 hitpoint)
        {
            HP.TakeDamage(Damage, hitpoint);
        }
    }
}