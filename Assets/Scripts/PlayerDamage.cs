using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    private PointSystem pointSystem;
    public TMP_Text playerdamage;

    // Start is called before the first frame update
    void Start()
    {
        playerdamage = GetComponent<TMP_Text>();
        pointSystem = FindObjectOfType<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        playerdamage.text = ("Player damage " + pointSystem.damage).ToString();
    }
}
