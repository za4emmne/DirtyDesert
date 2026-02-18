using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    private int difficultyLevel;

    void Start()
    {
        currentScore = 0;
        difficultyLevel = 1; // Starting difficulty level
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateDifficulty();
    }

    private void UpdateDifficulty()
    {
        if (currentScore >= 100 * difficultyLevel)
        {
            difficultyLevel++;
            Debug.Log("Difficulty increased to level: " + difficultyLevel);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetDifficultyLevel()
    {
        return difficultyLevel;
    }
}