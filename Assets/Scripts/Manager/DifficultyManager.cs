// DifficultyManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficulty;

    private void Start()
    {
        SetDifficulty(Difficulty.Medium); // Default difficulty
    }

    public void SetDifficulty(Difficulty newDifficulty)
    {
        currentDifficulty = newDifficulty;
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                // Set parameters for Easy difficulty
                break;
            case Difficulty.Medium:
                // Set parameters for Medium difficulty
                break;
            case Difficulty.Hard:
                // Set parameters for Hard difficulty
                break;
        }
        Debug.Log($"Difficulty set to: {currentDifficulty}");
    }
}