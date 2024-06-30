using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _speed;

    private void Start()
    {
        _speed = _gameManager.Speed;
    }

    private void OnEnable()
    {
        _gameManager.GameOver += OnStop;
        _gameManager.ChangeSpeed += OnChangeSpeed;
    }
    private void OnDisable()
    {
        _gameManager.GameOver -= OnStop;
        _gameManager.ChangeSpeed -= OnChangeSpeed;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void OnChangeSpeed()
    {
        _speed = _gameManager.Speed;
    }

    private void OnStop()
    {
        _speed = 0;
    }

}
