using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bigBossPrefab;
    public GameObject smallBossPrefab;
    public GameObject currentEnemy;
    [SerializeField] public GameObject smallBoss;
    [SerializeField] public GameObject bigBoss;
    public KillCount count;
    private PointSystem pointSystem;
    public bool spawning;
    public float health = 0.00f;
    public int maxHealth = 1;
    public float timeToRespawn = 1f;
    private float timeLeft;

    private void Start()
    {
        count = FindObjectOfType<KillCount>();
        pointSystem = FindObjectOfType<PointSystem>();
        timeLeft = timeToRespawn;
    }

    private void SpawnObject()
    {
        int SpawnPositionX = Random.Range(-4, 4);
        float SpawnPositionY = 0.3f;
        int SpawnPositionZ = Random.Range(-4, 4);

        Vector3 SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);

        currentEnemy =  Instantiate(enemyPrefab, SpawnPosition, Quaternion.identity);
        spawning = true;
        maxHealth++;
        health = maxHealth;
    }

    private void SpawnBigBoss()
    {
        int SpawnPositionX = Random.Range(-4, 4);
        float SpawnPositionY = 0.3f;
        int SpawnPositionZ = Random.Range(-4, 4);

        Vector3 SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);

        bigBoss = Instantiate(bigBossPrefab, SpawnPosition, Quaternion.identity);
        spawning = true;
        health = maxHealth * 3;

    }

    private void SpawnSmallBoss()
    {
        for (int i = 0; i < 4; i++)
        {
            int SpawnPositionX = Random.Range(-4, 4);
            float SpawnPositionY = 0.3f;
            int SpawnPositionZ = Random.Range(-4, 4);

            Vector3 SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);
            smallBoss = Instantiate(smallBossPrefab, SpawnPosition, Quaternion.identity);
            health = maxHealth;
        }
        spawning = true;
    }

    private void Update()
    {
        if (spawning == false)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                timeLeft = timeToRespawn;
                if (count.kills == 0)
                    SpawnObject();
                else if (count.kills%5 == 0)
                {
                    SpawnBigBoss();
                }
                else if (count.kills%4 == 0)
                {
                    SpawnSmallBoss();
                }
                else SpawnObject();
            }
        }
        if (spawning == true)
        {
            if (currentEnemy && currentEnemy.transform.position.y < -3)
            {
                Destroy(currentEnemy);
                spawning = false;
                count.kills++;
                pointSystem.points++;
            }
            if (smallBoss && smallBoss.transform.position.y < -3)
            {
                Destroy(smallBoss);
                spawning = false;
                count.kills++; 
                pointSystem.damage++; 
            }
            if (bigBoss && bigBoss.transform.position.y < -3)
            {
                Destroy(bigBoss);
                spawning = false;
                count.kills++;
                pointSystem.damage++;
            }
        }
     }
}

