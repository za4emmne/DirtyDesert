using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Вспомогательные скрипты")]
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private PlayerMovenment _playerJumping;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AudioSource _boomAudio;


    [Header("Мониторинг данных")]
    [SerializeField] private float _speed;

    private bool _isGameOver;
    private bool _isStopInstantiate;
    private float _speedStep;
    private float _playerGravityScale;

    public event Action SpawnTimeChanged;
    public event Action Play;
    public event Action GameOver;
    public event Action ChangeSpeed;

    public bool IsGameOver => _isGameOver;
    public float Speed => _speed;
    public bool IsStopInstantiate => _isStopInstantiate;

    private void Start()
    {
        _playerGravityScale = _playerBoomed.GetComponent<Rigidbody2D>().gravityScale;
        _isStopInstantiate = true;
        _speedStep = 0;
        _isGameOver = false;
    }

    public void StartPlayButtom()
    {
        _speed = 3;
        Play?.Invoke();
        //SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        ChangeSpeed?.Invoke();
    }

    public void StartMenuScene()
    {
        _speed = 0;
        ChangeSpeed?.Invoke();
        //SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += BoomTNT;
        _scoreManager.StepScoreChanged += AddSpeed;
        _playMenu.StartGame += StartPlayButtom;
    }
    private void OnDisable()
    {
        _scoreManager.StepScoreChanged -= AddSpeed;
        _playerBoomed.PlayerBoomed -= BoomTNT;
        _playMenu.StartGame -= StartPlayButtom;
    }

    private void AddSpeed()
    {
        if (_speed < 7)
            _speedStep = UnityEngine.Random.Range(0.5f, 1f);
        else
            _speedStep = UnityEngine.Random.Range(0.1f, 0.5f);

        _speed += _speedStep;
        _playerGravityScale += 0.07f;
        _playerJumping.AddJumpForce(7);

        ChangeSpeed?.Invoke();
        SpawnTimeChanged?.Invoke();
    }

    private void BoomTNT()
    {
        _speed = 0;
        GameOver?.Invoke();
        ChangeSpeed?.Invoke();
        _isStopInstantiate = true;
        _isGameOver = true;
        
    }
}