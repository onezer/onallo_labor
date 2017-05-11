using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{

    public class PlayerLeveling : MonoBehaviour
    {
        public int CurrentLevel;

        public float AbilityPwrPerLevel;

        public int MaxManaPerLevel;
        public int ManaRegenPerLevel;
        public int MaxHealthPerLevel;
        public int HealthRegenPerLevel;
        public int AutoAttackDmgPerLevel;
        public int XpToNextLevel;

        public float XpIncrease;

        public Slider expSlider;

        int CurrentExperience;

        public Text lvltext;

        PlayerMain playerMain;
        PlayerShooting Shoot;

        void Awake()
        {
            Shoot = GetComponentInChildren<PlayerShooting>();
            playerMain = GetComponent<PlayerMain>();
        }

        public void GainExperience(int xp)
        {
            CurrentExperience += xp;

            if(CurrentExperience >= XpToNextLevel)
            {
                Levelup();
            }
        }

        void Levelup()
        {
            CurrentExperience = CurrentExperience - XpToNextLevel;

            CurrentLevel++;

            XpToNextLevel = Mathf.RoundToInt((float)CurrentLevel * (float)XpToNextLevel * XpIncrease);


            playerMain.ManaRegen += ManaRegenPerLevel;
            playerMain.MaxMana += MaxManaPerLevel;
            playerMain.MaxHealth += MaxHealthPerLevel;
            playerMain.HpRegen += HealthRegenPerLevel;
            playerMain.AutoDamage += AutoAttackDmgPerLevel;
            playerMain.abilitypower += AbilityPwrPerLevel;
        }

        void Update()
        {
            expSlider.value = CurrentExperience;
            expSlider.maxValue = XpToNextLevel;

            lvltext.text = "Player Level: " + CurrentLevel;
        }
    }
}