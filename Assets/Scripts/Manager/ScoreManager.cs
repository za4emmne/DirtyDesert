using UnityEngine;
using System;
using UnityEngine.UI;
using YG;
//using System.Runtime.InteropServices;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private PlayerGetScore _player;
    [SerializeField] private int _minScore;
    [SerializeField] private int _maxScore;

    [Header("Мониторинг данных")]
    [SerializeField] private int _score;
    [SerializeField] private int _highScore;
    [SerializeField] private int _nextStepScore = 4;
    [SerializeField] private Text _scoreText;

    public event Action StepScoreChanged;
    public event Action HidedRules;

    public int HighScore => _highScore;
    public int Score => _score;
    private string _scoreWord;

    private void Awake()
    {
        if (YG2.isSDKEnabled)
        {
            GetLoad();
        }

        //_highScore = PlayerPrefs.GetInt("SaveScore");
        SwitchLanguage(YG2.lang);
        _score = 0;
    }
    public void SwitchLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                _scoreWord = "Очки: ";
                break;
            case "tr":
                _scoreWord = "Puan: ";
                break;
            case "en":
                _scoreWord = "Score: ";
                break;
        }
    }
    public void GetLoad()
    {
        _highScore = YG2.saves.score;
    }

    public void ClearHighScore()
    {
        //YandexGame.ResetSaveProgress();
        //YandexGame.SaveProgress();
        //PlayerPrefs.SetInt("SaveScore", _highScore);
    }

    private void OnEnable()
    {
        _player.PlayerGetedScore += AddScore;
        YG2.onGetSDKData += GetLoad;
        //YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        _player.PlayerGetedScore -= AddScore;
        YG2.onGetSDKData -= GetLoad;
        //YandexGame.GetDataEvent -= GetLoad;
    }

    private void ChangeScore()
    {
        _scoreText.text = _scoreWord + _score.ToString();
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
            //PlayerPrefs.SetInt("SaveScore", _highScore);

            YG2.saves.score = _highScore;
            YG2.SaveProgress();
        }
    }

    private void RandomStepScore()
    {
        int scoreStep = UnityEngine.Random.Range(_minScore, _maxScore);

        if (_nextStepScore == _score)
        {
            StepScoreChanged?.Invoke();
            _nextStepScore += scoreStep;
        }
    }
}
