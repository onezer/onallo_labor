using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{

    public class PlayerMana : MonoBehaviour
    {
        public int CurrentMana;
        public int MaxMana;

        public int ManaRegen;

        float timer = 0;

        public Slider ManaSlider;
        public Text ManaText;

        public void GainMana(int amount)
        {
            CurrentMana += amount;

            if(CurrentMana > MaxMana)
            {
                CurrentMana = MaxMana;
            }
        }

        public bool SpendMana(int amount)
        {
            if(amount > CurrentMana)
            {
                return false;
            }
            else
            {
                CurrentMana -= amount;
                return true;
            }
        }

        void Awake()
        {
            CurrentMana = MaxMana;
        }

        void Update()
        {
            ManaSlider.maxValue = MaxMana;
            ManaSlider.value = CurrentMana;
            ManaText.text = MaxMana + "/" + CurrentMana;

            timer += Time.deltaTime;

            if(timer >= 1)
            {
                GainMana(ManaRegen);
                timer = 0;
            }
        }
    }
}