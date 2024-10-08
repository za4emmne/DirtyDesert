using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 1;
    private Transform _transform;
    private PoolObject<T> _poolObject;
    [Header("���������� ������")]
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

    private void OnStart()
    {
        _transform = GetComponent<Transform>();
        _poolObject = GetComponent<PoolObject<T>>();
        _coroutine = StartCoroutine(Spawn());
    }

    private void OnStop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY;
        float maxPositionY = transform.position.y + _devationPositionY;

        while (true)
        {

            float positionY = Random.Range(minPositionY, maxPositionY);
            _spawnTime = Random.Range(_minDelay, _maxDelay);

            var waitForSeconds = new WaitForSeconds(_spawnTime);

            Vector3 spawnPoint = new Vector3(transform.position.x, positionY, transform.position.z);
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
