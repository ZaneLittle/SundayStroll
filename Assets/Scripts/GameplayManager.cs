using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    private static float particleBuffer;// Wait between death and rendering game over screen
    private static float score;         // Player's score
    private static float speed;         // Base speed of elements along the X plane
    private static bool gameplay;       // Denotes if the game is currently running

    public static Text gameOverText;
    public static Text finalScoreText;
    public static Text restartText;
    public static Text scoreText;

    public static void increaseScore(float increment)
    {
        score += increment;
    }
    
    public static bool getGameplay()
    {
        return gameplay;
    }

    public static float getSpeed()
    {
        return speed;
    }

    public static IEnumerator endGame()
    {
        gameplay = false;

        // Slow down to 0
        while (speed > 0)
        {
            speed = (speed / 2) - 0.001f;
            if (speed < 0)
            {
                speed = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }

        // Buffer for animations
        yield return new WaitForSeconds(particleBuffer);

        // Render game over screen
        gameOverText.text = "Game Over";
        finalScoreText.text = "Score: " + score.ToString("0.00");
        restartText.text = "[Click to Restart]";
    }

    private void Start()
    {
        // Retrieve static objects
        finalScoreText = GameObject
            .FindWithTag("FinalScoreText")
            .GetComponent<Text>() as Text;
        gameOverText = GameObject
            .FindWithTag("GameOverText")
            .GetComponent<Text>() as Text;
        restartText = GameObject
            .FindWithTag("RestartText")
            .GetComponent<Text>() as Text;
        scoreText = GameObject
            .FindWithTag("ScoreText")
    .       GetComponent<Text>() as Text;

        // Instantiate properties
        score = 0;
        speed = 0.05f;
        particleBuffer = 1.0f;
        gameOverText.text = "";
        finalScoreText.text = "";
        restartText.text = "";
        gameplay = true;
    }

    private void Update()
    {
        if (getGameplay())
        {
            increaseScore(Time.deltaTime);
            scoreText.text = "Score: " + score.ToString("0.00");
        }
        else
        {
            scoreText.text = "";
        }
    }
}
