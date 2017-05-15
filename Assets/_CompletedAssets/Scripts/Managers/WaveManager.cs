using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{

    public class WaveManager : MonoBehaviour {

        public int SpawnHellephant;
        public int SpawnZombear;
        public int SpawnZombunny;

        public float timeBetweenWaves;

        public int CurrentWave;

        public Text enemytext;
        public Text wavetext;

        public float DamageModifier;
        public float HpModifier;
        public float XPModifier;

        float timer = 0;

        bool invoked = false;


        public GameObject Enemymanager;
        WavePowerUp PowerUp;

        GameObject[] Enemies;

        void Awake()
        {
            //CurrentWave = 1;
            PowerUp = Enemymanager.GetComponent<WavePowerUp>();
            Spawn();
        }

        void PowerUpMinions()
        {
            PowerUp.DamageModifier += DamageModifier;
            PowerUp.HpModifier += HpModifier;
            PowerUp.XPModifier += XPModifier;
        }

        int CalculateMinionNumber(int MinionType)
        {
            if(CurrentWave % 10 == 0)
            {
                
                return 1;
            }


            switch(MinionType)
            {
                case 1: return CurrentWave % 10;
                case 2: return Mathf.RoundToInt((CurrentWave % 10) * 1.5f);
                case 3: return (CurrentWave % 10) * 2;
                default: return 0;
            }
        }

        void Spawn()
        {
            if(CurrentWave % 10 == 0) PowerUpMinions();

            SpawnHellephant = CalculateMinionNumber(1);
            SpawnZombear = CalculateMinionNumber(2);
            SpawnZombunny = CalculateMinionNumber(3);
        }

        void NextWave()
        {
            CurrentWave ++;
            Spawn();
            invoked = false;
        }

        void Update() {

            timer += Time.deltaTime;

            Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            enemytext.text = "Enemy Remaining: " + Enemies.Length;
            wavetext.text = "Current Wave: " + CurrentWave;

            if (Enemies.Length == 0 && SpawnHellephant == 0 && SpawnZombear ==0 && SpawnZombunny == 0)
            {
                if (invoked == false)
                {
                    Invoke("NextWave", timeBetweenWaves);
                    invoked = true;
                }
            }
        }
    }
}