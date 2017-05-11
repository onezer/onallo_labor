using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class EnemyBomberAttack : MonoBehaviour
    {

        public float timeBetweenAttacks;     // The time in seconds between each attack.
        public int attackDamage;               // The amount of health taken away per attack.
        public GameObject bomb;
        public float ExplosionRange;
        public float AttackRange;
        public float ThrowingDegree;

        GameObject currentBomb;

        Animator anim;                              // Reference to the animator component.
        GameObject player;                          // Reference to the player GameObject.
        PlayerHealth playerHealth;                  // Reference to the player's health.
        EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        float timer;                                // Timer for counting up to the next attack.
        EnemyMovement enemyMovement;

        UnityEngine.AI.NavMeshAgent nav;

        Vector3 playerPosition;

        void Awake()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent<Animator>();
            enemyMovement = GetComponent<EnemyMovement>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            GetComponent<SphereCollider>().radius = AttackRange;

            nav.stoppingDistance = AttackRange;
        }


        void OnTriggerEnter(Collider other)
        {
            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
            }
        }


        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }

        bool enraged = false;

        void Enrage()
        {
            enraged = true;

            timeBetweenAttacks /= 2;
        }

        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && enemyMovement.isStunned == false)
            {
                // ... attack.
                Attack();
            }

            // If the player has zero or less health...
            if (playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger("PlayerDead");
            }

            if(enemyMovement.isEnraged && !enraged)
            {
                Enrage();
            }
        }




        void Attack()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if (playerHealth.currentHealth > 0)
            {
                currentBomb = Instantiate(bomb);

                currentBomb.GetComponent<BombMechanics>().range = ExplosionRange;
                currentBomb.GetComponent<BombMechanics>().damage = attackDamage;

                currentBomb.transform.position = transform.position + new Vector3(0f,1f,0f);

                playerPosition = player.transform.position;

                Vector3 throwing = BombAbility.CalculateThrow(transform.position,playerPosition,ThrowingDegree);

                currentBomb.GetComponent<Rigidbody>().AddRelativeForce(throwing, ForceMode.Impulse);
            }
        }
    }
}

