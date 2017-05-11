using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    static public GameObject[] EnemyGroup;
    static public int enemiesInGame = 0;


    void Push(GameObject enemy)
    {
        GameObject[] temp;

        temp = new GameObject[enemiesInGame];

        for(int i = 0; i < enemiesInGame - 1; i++)
        {
            temp[i] = EnemyGroup[i];
        }

        temp[enemiesInGame - 1] = enemy;

        EnemyGroup = temp;
    }


    void Pop(GameObject enemy)
    {
        GameObject[] temp;
        temp = new GameObject[enemiesInGame];

        int j = 0;
        for(int i = 0; i < enemiesInGame; i++)
        {
            if(EnemyGroup[i] != enemy)
            {
                temp[j] = EnemyGroup[i];
                j++;
            }
        }

        Destroy(enemy, 2f);
    }

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    public void KillEnemy(GameObject enemy)
    {
        enemiesInGame--;
        Pop(enemy);
    }

    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        enemiesInGame++;

        EnemyGroup = new GameObject[enemiesInGame];

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
