using UnityEngine;
using System.Collections;

public class SpawnTNT : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _transform;
    [SerializeField] private PoolObjectTNT _poolObject;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
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
        _coroutine = StartCoroutine(Spawn());
    }

    private void OnStop()
    {
        if(_coroutine != null )
        StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _spawnTime = Random.Range(_minDelay, _maxDelay);

            var waitForSeconds = new WaitForSeconds(_spawnTime);

            Vector3 spawnPoint = _transform.position;
            var tnt = _poolObject.GetObject();
            tnt.gameObject.SetActive(true);
            tnt.transform.position = spawnPoint;

            yield return waitForSeconds;
        }
    }

    private void ChangeSpawnTime()
    {
        _minDelay -= 0.5f;
        _maxDelay -= 0.5f;

        if (_minDelay < 3)
        {
            _minDelay += 0.3f;
            _maxDelay += 0.3f;
        }
    }

    private void GetTNT()
    {

    }
}