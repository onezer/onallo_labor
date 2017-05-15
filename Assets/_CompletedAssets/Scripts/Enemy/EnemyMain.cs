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
        EnemyArcherAttack Archer;
        EnemyBomberAttack Bomber;
        EnemyAttack Attack;

        string Name;

        void Awake()
        {
            Name = gameObject.name;

            HP = GetComponent<EnemyHealth>();
            MOV = GetComponent<EnemyMovement>();

            switch(Name)
            {
                case "Hellephant": Bomber = GetComponent<EnemyBomberAttack>(); break;
                case "ZomBear": Archer = GetComponent<EnemyArcherAttack>(); break;
                case "ZomBunny": Attack = GetComponent<EnemyAttack>(); break;
            }
            
            
            
        }

        public int XPValue
        {
            get
            {
                return HP.xpValue;
            }

            set
            {
                HP.xpValue = value;
            }
        }

        public int StartingHP
        {
            get
            {
                return HP.startingHealth;
            }

            set
            {
                HP.startingHealth = value;
            }

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

        public int CurrentHP
        {
            get
            {
                return HP.currentHealth;
            }

            set
            {
                HP.currentHealth = value;
            }
        }

        public int AttackDMG
        {
            get
            {
                switch (Name)
                {
                    case "Hellephant": return Bomber.attackDamage;
                    case "ZomBear": return Archer.attackDamage;
                    case "ZomBunny": return Attack.attackDamage;
                }

                return 0;
            }

            set
            {
                switch (Name)
                {
                    case "Hellephant": Bomber.attackDamage = value; break;
                    case "ZomBear": Archer.attackDamage = value; break;
                    case "ZomBunny": Attack.attackDamage = value; break;
                }
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