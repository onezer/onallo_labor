using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour, Slowable, Stunnable
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        float originalSpeed;

        public bool isEnraged;
        public float TimeToEnrage;

        bool Enraged;

        public bool isStunned;
        float timer;
        float stunTime;

        float slowtimer = 0;

        float enrageTimer;

        bool isSlowed = false;

        Animator anim;


        public void Slow(float Percent, float Duration)
        {
            if (isSlowed == false)
            {
                isSlowed = true;
                nav.speed -= nav.speed * Percent * 0.01f;
                slowtimer = Duration;
            }
        }

        public Vector3 GetMovement()
        {
            return new Vector3(0f, 0f, 0f);
        }

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            isStunned = false;
            anim = GetComponent<Animator>();
            originalSpeed = nav.speed;
            enrageTimer = 0;
            isEnraged = false;
        }

        public void Stun(float Time)
        {
            stunTime = Time;
            isStunned = true;
        }

        protected void FollowPlayer()
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !isStunned)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.enabled = true;
                nav.SetDestination(player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }

        protected void Update ()
        {
            anim.SetBool("Stunned", isStunned);

            enrageTimer += Time.deltaTime;

            if(enrageTimer >= TimeToEnrage)
            {
                isEnraged = true;
            }

            if(isEnraged && !Enraged)
            {
                originalSpeed *= 2f;
                Enraged = true;
            }
            

            if(isStunned)
            {
                timer += Time.deltaTime;
            }
            

            if(isStunned && timer >= stunTime)
            {
                isStunned = false;
                timer = 0f;
            }

            if(slowtimer > 0)
            {
                slowtimer -= Time.deltaTime;
            }
            else
            {
                slowtimer = 0;
                nav.speed = originalSpeed;
                isSlowed = false;
            }

            FollowPlayer();
        }
    }
}