
using UnityEngine;
namespace CompleteProject
{
    public class Stunball : MonoBehaviour
    {
        public float timeBetweenAttacks;
        public float StunTime;
        public float effectsDisplayTime;

        float timer;
        int enemyInRange;
        public float StunRange;
        bool DisabledEffects;

        public LineRenderer StunLine;

        GameObject[] GroupOfEnemy;
        GameObject[] GroupOfEnemyInRange;
        LineRenderer[] GroupOfLines;


        bool IsInRange(GameObject enemy)
        {
            bool x = false;

            if (Vector3.Distance(enemy.transform.position, transform.position) <= StunRange)
            {
                
                x = true;
            }

            return x;
        }

        void MakeArray()
        {
            int len = 0;
            for(int i = 0; i < GroupOfEnemy.Length; i++)
            {
                if(IsInRange(GroupOfEnemy[i]))
                {
                    len++;
                }
            }

            GroupOfEnemyInRange = new GameObject[len];

            int j = 0;
            for(int i = 0; i < GroupOfEnemy.Length; i++)
            {
                if (IsInRange(GroupOfEnemy[i]))
                {
                    GroupOfEnemyInRange[j] = GroupOfEnemy[i];
                    j++;
                }
            }
        }

        public void DisableEffects()
        {
            DisabledEffects = true;
            if (GroupOfLines == null)
                return;
            for(int i = 0; i < GroupOfLines.Length; i++)
            {
                Destroy(GroupOfLines[i]);
            }
        }

        void Update()
        {
            timer += Time.deltaTime;

            GroupOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            MakeArray();
            enemyInRange = GroupOfEnemyInRange.Length;

            if (timer >= timeBetweenAttacks && enemyInRange > 0)
            {
                Attack();
            }


            if(timer >= timeBetweenAttacks * effectsDisplayTime)
            {
                DisableEffects();
            }

            if (GroupOfLines != null && !DisabledEffects)
            {
                for (int i = 0; i < GroupOfLines.Length; i++)
                {
                    GroupOfLines[i].SetPosition(0, transform.position);
                }
            }
        }

        void Attack()
        {
            timer = 0f;
            GroupOfLines = new LineRenderer[enemyInRange];

            DisabledEffects = false;

            for (int i = 0; i < enemyInRange; i++)
            {
                if (GroupOfEnemyInRange[i].GetComponent<EnemyHealth>().currentHealth > 0)
                {
                    GroupOfEnemyInRange[i].GetComponent<EnemyMovement>().Stun(StunTime);
                }
                
            }

            for(int i = 0; i < enemyInRange; i++)
            {
                GroupOfLines[i] = Instantiate(StunLine, transform.position, transform.rotation);
                GroupOfLines[i].SetPosition(0, transform.position);
                if (GroupOfEnemyInRange[i].GetComponent<EnemyHealth>().currentHealth > 0)
                {
                    GroupOfLines[i].SetPosition(1, GroupOfEnemyInRange[i].transform.position);
                }
                else
                {
                    GroupOfLines[i].enabled = false;
                }
            }


            

        }
    }
}