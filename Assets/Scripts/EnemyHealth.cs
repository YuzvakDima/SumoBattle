using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public TMP_Text enemyHealth;
    private SpawnEnemy spawn;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<TMP_Text>();
        spawn = FindObjectOfType<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.spawning == false)
            enemyHealth.text = ("Enemy health: " + 0);
        if (spawn.spawning == true )
            enemyHealth.text = ("Enemy health: " + spawn.health.ToString());
    }
}
