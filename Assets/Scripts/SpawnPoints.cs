using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public bool spawning = false;
    
    private void SpawnObject()
    {
        int SpawnPositionX = Random.Range(-4, 4);
        float SpawnPositionY = 0.3f;
        int SpawnPositionZ = Random.Range(-4, 4);

        Vector3 SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY, SpawnPositionZ);

        Instantiate (spawnPoint, SpawnPosition, Quaternion.identity);
        spawning = true;

    }

    private void Update()
    {
        if (spawning == false)
            SpawnObject();
    }
}
