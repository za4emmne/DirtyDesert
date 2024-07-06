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
    [SerializeField] private UnityEngine.GameObject _coinCount;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _coinsInWallet;

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
        _coinCount.SetActive(false);
    }

    private void Start()
    {
        ChangeHighSCore();
        ChangeCoins();
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += GameOver;
        _scoreManager.HidedRules += HideRules;
    }

    private void OnDisable()
    {
        _playerBoomed.PlayerBoomed -= GameOver;
        _scoreManager.HidedRules -= HideRules;
    }

    public void RestartPlay()
    {
        SceneManager.LoadScene("Game");
        Play();
    }

    public void ChangeHighSCore()
    {
        _highScoreText.text = "Рекорд: " + _scoreManager.HighScore.ToString();
    }

    public void ChangeCoins()
    {
        _coinsInWallet.text = _wallet.Coin.ToString() + "";
    }

    public void Play()
    {
        StartGame?.Invoke();
        _buttomPause.SetActive(true);
        _menu.SetActive(false);
        _rulesGame.SetActive(true);
        _nameGame.SetActive(false);
        _scoreObject.SetActive(true);
        _coinCount.SetActive(true);
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
            _rulesGame.SetActive(false);
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        _buttomPause.SetActive(false);
    }
}
