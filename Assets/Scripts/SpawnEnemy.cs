using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;
    public bool spawning;
    public int health = 0;
    public int maxHealth = 1;
    public float timeToRespawn = 1f;
    private float timeLeft;

    private void Start()
    {
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

    private void Update()
    {
        if (spawning == false)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                timeLeft = timeToRespawn;
                SpawnObject();
            }
        }
        if (spawning == true)
            if (currentEnemy.transform.position.y < -3)
            {
                Destroy(currentEnemy);
                spawning=false;
            }
     }
}
