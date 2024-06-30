using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameManager))]

public class PlayMenu : MonoBehaviour
{
    [Header("Объекты меню")]
    [SerializeField] private UnityEngine.GameObject _nameGame;
    [SerializeField] private UnityEngine.GameObject _gameOver;
    [SerializeField] private UnityEngine.GameObject _pauseMenu;
    [SerializeField] private UnityEngine.GameObject _menu;
    [SerializeField] private UnityEngine.GameObject _buttomPause;
    [SerializeField] private UnityEngine.GameObject _scoreObject;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;

    [Header("Вспомогательные скрипты")]
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UnityEngine.GameObject _rulesGame;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Wallet _wallet;

    public event Action StartGame;
    private int _score;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
        _gameOver.SetActive(false);
        _rulesGame.SetActive(false);
        _buttomPause.SetActive(false);
        _scoreObject.SetActive(false);
    }

    private void Start()
    {
        ChangeHighSCore();
    }


    private void Update()
    {
        _score = _scoreManager.Score; //сделать через события
        HideRules(); //сделать через события
        _scoreText.text = "Очки: " + _score.ToString(); //сделать через события
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += GameOver;
    }

    private void OnDisable()
    {
        _playerBoomed.PlayerBoomed -= GameOver;
    }

    public void ChangeHighSCore()
    {
        _highScoreText.text = "Рекорд: " + _scoreManager.HighScore.ToString();
    }

    public void Play()
    {
        StartGame?.Invoke();
        _buttomPause.SetActive(true);
        _menu.SetActive(false);
        _rulesGame.SetActive(true);
        _nameGame.SetActive(false);
        _scoreObject.SetActive(true);
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void HideRules()
    {
        if (_score > 1)
            _rulesGame.SetActive(false);
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        _buttomPause.SetActive(false);
    }
}
