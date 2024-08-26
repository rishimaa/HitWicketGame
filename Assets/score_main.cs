using UnityEngine;
using TMPro;

public class DoofusScoreManager : MonoBehaviour
{
    public int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        // Initialize the score text at the start
        UpdateScoreText();
    }

    void Update()
    {
        // Check if the player's y position is below -35
        if (playerTransform.position.y < -10 || score>50)
        {
            DisplayGameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        score++;
        UpdateScoreText(); // Update the score display
        Debug.Log(score);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void DisplayGameOver()
    {
        if (scoreText != null)
        {
            scoreText.text = "Game Over! Final Score: " + score.ToString();
        }

        // Additional logic for game over can be added here (e.g., stopping the game, disabling player controls, etc.)
    }
}