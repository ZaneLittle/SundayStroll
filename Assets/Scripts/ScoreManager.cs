using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float score;  // Denotes player's score
    public static bool gameplay;       // Denotes if the game is currently running
    public Text scoreText;

    private void Start()
    {
        score = 0;
        gameplay = true;
    }

    private void Update()
    {
        if (gameplay)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + score.ToString("0.00");

        }
    }
}
