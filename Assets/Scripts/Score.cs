using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int ballValue;

    private int score;


    void Start()
    {
        score = 0;
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += ballValue;
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + System.Environment.NewLine + Mathf.RoundToInt(score);
    }
}
