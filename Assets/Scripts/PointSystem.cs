using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public float points = 1.00f;
    private SpawnPoints spawnPoints;
    public float damage = 1.00f;

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
        if (points >= 5)
        {
            damage++;
            points = 0;
        }
    }
}
