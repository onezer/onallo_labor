﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public int Type;

        public float HpModifier;
        public float DamageModifier;
        public float XPModifier;


        EnemyMain Main;

        int Amount;

        public GameObject waveManager;

        WaveManager Wave;
        WavePowerUp PowerUp;

        void Start ()
        {
            Wave = waveManager.GetComponent<WaveManager>();
            PowerUp = GetComponent<WavePowerUp>();

            RefreshAmount();

            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }

        void RefreshAmount()
        {
            switch (Type)
            {
                case 1:
                    Amount = Wave.SpawnHellephant;
                    break;

                case 2:
                    Amount = Wave.SpawnZombear;
                    break;

                case 3:
                    Amount = Wave.SpawnZombunny;
                    break;

            }
        }

        void RefreshNumbers()
        {
            switch (Type)
            {
                case 1:
                    Wave.SpawnHellephant = Amount;
                    break;

                case 2:
                    Wave.SpawnZombear = Amount;
                    break;

                case 3:
                    Wave.SpawnZombunny = Amount;
                    break;

            }
        }

        void Update()
        {
            HpModifier = PowerUp.HpModifier;
            XPModifier = PowerUp.XPModifier;
            DamageModifier = PowerUp.DamageModifier;
        }

        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            if (Amount > 0)
            {

                // Find a random index between zero and one less than the number of spawn points.
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                GameObject SpawnedEnemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                Main = SpawnedEnemy.GetComponent<EnemyMain>();
                Main.StartingHP = Mathf.RoundToInt(Main.StartingHP * HpModifier);
                Main.CurrentHP = Main.StartingHP;
                Main.AttackDMG = Mathf.RoundToInt(Main.AttackDMG * DamageModifier);
                Main.XPValue = Mathf.RoundToInt(Main.XPValue * XPModifier);
                Amount--;
                RefreshNumbers();
            }
            RefreshAmount();
        }

    }
}