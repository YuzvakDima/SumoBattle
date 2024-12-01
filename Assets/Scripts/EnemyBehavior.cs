using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    private SpawnEnemy spawnenemy;
    private SpawnPoints spawnPoints;
    private PointSystem pointsystem;
    private GameObject point;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnenemy = FindObjectOfType<SpawnEnemy>();
        player = GameObject.FindWithTag("Player");
        spawnPoints = FindObjectOfType<SpawnPoints>();
        pointsystem = FindObjectOfType<PointSystem>();
    }
    private void Update()
    {
        point = GameObject.FindWithTag("Point");
        if (!player)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (spawnenemy.health > 1)
        {
            Vector3 lookDirection = player.transform.position - transform.position;
            rb.AddForce(lookDirection.normalized * speed);
        }
        if (spawnenemy.health == 1)
        {
            Vector3 lookDirection = point.transform.position - transform.position;
            rb.AddForce(lookDirection.normalized * (speed * 0.5f));
        }
        if (spawnenemy.health <= 0)
        {
            Destroy(gameObject);
            spawnenemy.spawning = false;
            pointsystem.points++;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            spawnenemy.health = spawnenemy.health - pointsystem.damage;
        }
        if (collision.collider.tag == "Point")
        {
            spawnenemy.health++;
            Destroy(collision.gameObject);
            spawnPoints.spawning = false;
        }
    }
}
