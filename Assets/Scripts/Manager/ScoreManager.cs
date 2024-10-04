using UnityEngine;
using System;
using UnityEngine.UI;
//using System.Runtime.InteropServices;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private PlayerGetScore _player;

    [Header("Мониторинг данных")]
    [SerializeField] private int _score;
    [SerializeField] private int _highScore;
    [SerializeField] private int _nextStepScore = 4;
    [SerializeField] private Text _scoreText;

    public event Action StepScoreChanged;
    public event Action HidedRules;

    public int HighScore => _highScore;
    public int Score => _score;

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("SaveScore");
        _score = 0;
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

    private void ChangeScore()
    {
        _scoreText.text = "Очки: " + _score.ToString();
    }

    private void AddScore()
    {
        _score++;

        if (_score == 3)
        {
            HidedRules?.Invoke();
        }

        RandomStepScore();
        ChangeScore();
        GetHighScore();
    }

    private void GetHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;

//#if !UNITY_EDITOR && UNITY_WEBGL
//            Progress.Instance.Save();
//#endif   
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
