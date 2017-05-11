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

        float timer = 0;

        bool invoked = false;

        GameObject[] Enemies;

        void Awake()
        {
            CurrentWave = 1;
            Spawn();
        }

        void Spawn()
        {
            SpawnHellephant = CurrentWave;
            SpawnZombear = Mathf.RoundToInt(CurrentWave * 1.5f);
            SpawnZombunny = CurrentWave * 2;
        }

        void NextWave()
        {
            CurrentWave++;
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