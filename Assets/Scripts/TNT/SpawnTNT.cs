using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnTNT : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _transform;
    [SerializeField] private PoolObjectTNT _poolObject;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [Header("Мониторинг данных")]
    [SerializeField] private float _spawnTime;
    private float _speed;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _gameManager.Play += OnStart;
        _gameManager.SpawnTimeChanged += ChangeSpawnTime;
        _gameManager.GameOver += OnStop;
        //_gameManager.ChangeSpeed += OnChangeSpeed;
    }

    private void OnDisable()
    {
        _gameManager.Play -= OnStart;
        _gameManager.SpawnTimeChanged -= ChangeSpawnTime;
        _gameManager.GameOver -= OnStop;
        //_gameManager.ChangeSpeed -= OnChangeSpeed;
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

            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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

        if (_minDelay < 2)
        {
            _minDelay += 0.3f;
            _maxDelay += 0.3f;
        }
    }

    private void RandomGetTNT()
    {

    }

    //private void OnChangeSpeed()
    //{
    //    if( _tnt != null )
    //        _tnt.Speed(_gameManager.Speed);
    //}
}
