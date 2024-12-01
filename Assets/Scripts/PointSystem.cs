using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int points = 1;
    private SpawnPoints spawnPoints;
    public int damage = 1;

    private void Start()
    {
        spawnPoints = FindObjectOfType<SpawnPoints>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Point")
        {
            points++;
            Destroy(collision.gameObject);
            spawnPoints.spawning = false;
        }
    }

    private void Update()
    {
        if (points == 5)
        {
            damage++;
            points = 0;
        }
    }
}
