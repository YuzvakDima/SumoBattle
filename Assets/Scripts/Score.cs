using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text score;
    private PointSystem pointSystem;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
        pointSystem = FindObjectOfType<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = ("Score: " + pointSystem.points.ToString());
    }
}
