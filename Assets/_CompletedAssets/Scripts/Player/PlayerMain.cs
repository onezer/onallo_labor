using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompleteProject
{
    public class PlayerMain : MonoBehaviour ,MainModule {
        PlayerHealth HP;
        PlayerMovement MOV;
        PlayerLeveling Lvl;
        PlayerMana Mana;
        PlayerShooting Shoot;
        Ability ability;

       public float abilitypower;

        void Awake()
        {
            abilitypower = 1;
            HP = GetComponent<PlayerHealth>();
            MOV = GetComponent<PlayerMovement>();
            Lvl = GetComponent<PlayerLeveling>();
            Mana = GetComponent<PlayerMana>();
            Shoot = GetComponentInChildren<PlayerShooting>();
            ability = GetComponent<Ability>();
        }

        public int AutoDamage
        {
            get
            {
                return Shoot.damagePerShot;
            }

            set
            {
                Shoot.damagePerShot = value;
            }
        }

        public int CurrentMana
        {
            get
            {
                return Mana.CurrentMana;
            }
        }

        public int MaxMana
        {
            get
            {
                return Mana.MaxMana;
            }

            set
            {
                Mana.MaxMana = value;
            }
        }

        public int ManaRegen
        {
            get
            {
                return Mana.ManaRegen;
            }

            set
            {
                Mana.ManaRegen = value;
            }
        }

        public void GainMana(int amount)
        {
            Mana.GainMana(amount);
        }

        public bool SpendMana(int amount)
        {
            return Mana.SpendMana(amount);
        }

        public int CurrentLevel
        {
            get
            {
                return Lvl.CurrentLevel;
            }
        }

        public int CurrentHealth
        {
            get
            {
                return HP.currentHealth;
            }
        }

        public int HpRegen
        {
            get
            {
                return HP.HpRegen;
            }

            set
            {
                HP.HpRegen = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return HP.MaxHealth;
            }

            set
            {
                HP.MaxHealth = value;
            }
        }



        public void GainExperience(int xp)
        {
            Lvl.GainExperience(xp);
        }

        public int GetLevel()
        {
            return Lvl.CurrentLevel;
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
            HP.TakeDamage(Damage);
        }
    }
}