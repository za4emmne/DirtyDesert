using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameManager))]

public class PlayMenu : MonoBehaviour
{
    [Header("Объекты меню")]
    [SerializeField] private GameObject _nameGame;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _buttomPause;
    [SerializeField] private GameObject _scoreObject;
    [SerializeField] private GameObject _coinCount;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _upButtom;
    [SerializeField] private GameObject _setting;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _coinsInWallet;
    [SerializeField] private Text _gameRulesText;

    [Header("Вспомогательные скрипты")]
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Wallet _wallet;

    public event Action StartGame;
    private int _isRestart;

    private void Awake()
    {
        _isRestart = PlayerPrefs.GetInt("Restart");
        _pauseMenu.SetActive(false);
        _gameOver.SetActive(false);
        _gameRulesText.gameObject.SetActive(false);
        _buttomPause.SetActive(false);
        _scoreObject.SetActive(false);
        _coinCount.SetActive(false);
        _shop.SetActive(false);
        _upButtom.SetActive(false);
        _setting.SetActive(false);
    }

    private void Start()
    {
        if (_isRestart == 0)
        {
            ChangeHighSCore();
            ChangeCoins();
        }
        else
            Play();

        if (Application.isMobilePlatform)
            _gameRulesText.text = "Тапни на кнопку снизу, чтобы прыгать";
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

    public void SettingWindow()
    {
        _setting.SetActive(true);
    }

    public void HideSettingWindow()
    {
        _setting.SetActive(false);
    }

    public void RestartPlay()
    {
        PlayerPrefs.SetInt("Restart", 1);
        SceneManager.LoadScene("Game");
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
        _gameRulesText.gameObject.SetActive(true);
        _nameGame.SetActive(false);
        _scoreObject.SetActive(true);
        _coinCount.SetActive(true);
        _upButtom.SetActive(true);
        PlayerPrefs.SetInt("Restart", 0);
    }

    public void Shop()
    {
        _shop.SetActive(true);
    }

    public void CloseShop()
    {
        _shop.SetActive(false);
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _upButtom.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        _pauseMenu.SetActive(false);
        _upButtom.SetActive(true);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    private void HideRules()
    {
        _gameRulesText.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        _buttomPause.SetActive(false);
        _upButtom.SetActive(false);
    }
}
