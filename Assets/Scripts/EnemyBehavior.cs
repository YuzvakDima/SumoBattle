using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    private SpawnEnemy spawnEnemy;
    private SpawnPoints spawnPoints;
    private PointSystem pointSystem;
    private GameObject point;
    private KillCount count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        player = GameObject.FindWithTag("Player");
        spawnPoints = FindObjectOfType<SpawnPoints>();
        pointSystem = FindObjectOfType<PointSystem>();
        count = FindObjectOfType<KillCount>();
    }
    private void Update()
    {
        point = GameObject.FindWithTag("Point");
        if (!player)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (spawnEnemy.health <= 0)
        {
            Destroy(gameObject);
            spawnEnemy.spawning = false;
            if (spawnEnemy.currentEnemy)
            {
                pointSystem.points++;
                count.kills++;
            }
            else if (spawnEnemy.smallBoss)
            {
                pointSystem.points = pointSystem.points + 0.25f;
                count.kills = count.kills + 0.25f;
            }
            else if (spawnEnemy.bigBoss)
            {
                pointSystem.points++;
                count.kills++;
            }
        }
        else if (spawnEnemy.health == 1 || spawnEnemy.health <= pointSystem.damage)
        {
            Vector3 lookDirection = point.transform.position - transform.position;
            rb.AddForce(lookDirection.normalized * (speed * 0.5f));
        }
        else if (spawnEnemy.health > pointSystem.damage)
        {
            Vector3 lookDirection = player.transform.position - transform.position;
            rb.AddForce(lookDirection.normalized * speed);
        }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            spawnEnemy.health = spawnEnemy.health - pointSystem.damage;
        }
        if (collision.collider.tag == "Point")
        {
            spawnEnemy.health++;
            Destroy(collision.gameObject);
            spawnPoints.spawning = false;
        }
    }
}
