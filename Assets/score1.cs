using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    private int score = 0; // Initial score

    // Call this method to update the score
    public void UpdateScore(int newScore)
    {
        score = newScore;
        scoreText.text = "Score: " + score.ToString();
    }
}