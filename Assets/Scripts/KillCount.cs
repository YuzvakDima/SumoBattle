using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    private EnemyBehavior enemyBehavior;
    public TMP_Text killsCount; 
    public float kills = 1.00f;
    void Start()
    {
        enemyBehavior = FindObjectOfType<EnemyBehavior>();
        killsCount = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killsCount.text = ("Counter: " + kills).ToString();
    }
}
