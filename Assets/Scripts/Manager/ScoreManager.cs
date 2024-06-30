using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerGetScore _player;

    [Header("Мониторинг данных")]
    [SerializeField] private int _score;
    [SerializeField] private int _highScore;
    [SerializeField] private int _nextStepScore = 4;

    public event Action StepScoreChanged;

    public int HighScore => _highScore;
    public int Score => _score;

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("SaveScore");
        _score = 0;
    }

    private void Update()
    {
        RandomStepScore();
    }

    public void ClearHighScore()
    {
        _highScore = 0;
        PlayerPrefs.SetInt("SaveScore", _highScore);
    }

    private void OnEnable()
    {
        _player.PlayerGetedScore += AddScore;
    }

    private void OnDisable()
    {
        _player.PlayerGetedScore -= AddScore;
    }

    private void AddScore()
    {
        _score++;
        GetHighScore();
    }

    private void GetHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("SaveScore", _highScore);
        }
    }

    private void RandomStepScore()
    {
        int scoreStep = UnityEngine.Random.Range(3, 6);

        if (_nextStepScore == _score)
        {
            StepScoreChanged?.Invoke();
            _nextStepScore += scoreStep;
        }
    }
}
