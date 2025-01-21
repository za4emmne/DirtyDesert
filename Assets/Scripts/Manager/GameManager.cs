using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG.Insides;

public class GameManager : MonoBehaviour
{
    [Header("Вспомогательные скрипты")]
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private PlayerMovenment _playerJumping;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioMixerGroup _audioMixer;
    //[SerializeField] private OrientationManager _orientationManager;

    [Header("Мониторинг данных")]
    [SerializeField] private float _speed;

    private bool _isStopInstantiate;
    private float _speedStep;
    private float _playerGravityScale;

    public event Action SpawnTimeChanged;
    public event Action Play;
    public event Action GameOver;
    public event Action ChangeSpeed;

    public float Speed => _speed;
    public bool IsStopInstantiate => _isStopInstantiate;

    private void Awake()
    {
        YGInsides.LoadProgress();
    }

    private void Start()
    {

        _playerGravityScale = _playerBoomed.GetComponent<Rigidbody2D>().gravityScale;
        _isStopInstantiate = true;
        _speedStep = 0;
        _slider.value = 1;
       // _orientationManager.OnChanged();
    }

    public void ToggleMusic(bool enabled)
    {
        if (_toggle.isOn)
            _audioMixer.audioMixer.SetFloat("Music", 0);
        else
            _audioMixer.audioMixer.SetFloat("Music", -80);
    }

    public void ChangeVolume(float volume)
    {
        volume = _slider.value;

        if (volume == 0)
            volume += 0.000001f;

        _audioMixer.audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void StartPlayButtom()
    {
        _speed = 3;
        Play?.Invoke();
        Time.timeScale = 1;
        ChangeSpeed?.Invoke();
    }

    public void StartMenuScene()
    {
        _speed = 0;
        ChangeSpeed?.Invoke();
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
    }
}