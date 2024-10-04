using System.Collections;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    private Transform _transform;
    private PoolObjectCoin _poolObject;

    [Header("Мониторинг данных")]
    [SerializeField] private float _spawnTime;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _gameManager.Play += OnStart;
        _gameManager.SpawnTimeChanged += ChangeSpawnTime;
        _gameManager.GameOver += OnStop;
    }

    private void OnDisable()
    {
        _gameManager.Play -= OnStart;
        _gameManager.SpawnTimeChanged -= ChangeSpawnTime;
        _gameManager.GameOver -= OnStop;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _poolObject = GetComponent<PoolObjectCoin>();
    }

    private void OnStart()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    private void OnStop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _spawnTime = Random.Range(_minDelay, _maxDelay);

            var waitForSeconds = new WaitForSeconds(_spawnTime);

            Vector3 spawnPoint = _transform.position;
            var obj = _poolObject.GetObject();

            obj.gameObject.SetActive(true);
            obj.transform.position = spawnPoint;

            yield return waitForSeconds;
        }
    }

    private void ChangeSpawnTime()
    {
        _minDelay -= 0.5f;
        _maxDelay -= 0.5f;

        if (_minDelay < 2)
        {
            _minDelay += 0.3f;
            _maxDelay += 0.3f;
        }
    }
}
