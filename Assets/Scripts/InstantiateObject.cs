using System.Collections;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UnityEngine.GameObject[] _templates;
    [SerializeField] private PlayerBoomTNT _playerBoomed;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 0;
    [SerializeField] private float _spawnTime;

    private int _objectNumber;
    private Coroutine _coroutine;

    private void Start()
    {
        //_isGameOver = false;
        
    }

    private void OnEnable()
    {
        _playerBoomed.PlayerBoomed += StopInstantieting;
        _gameManager.SpawnTimeChanged += ChangeSpawnTime;
        _gameManager.Play += StartInstantiating;
    }

    private void OnDisable()
    {
        _playerBoomed.PlayerBoomed -= StopInstantieting;
        _gameManager.SpawnTimeChanged -= ChangeSpawnTime;
        _gameManager.Play -= StartInstantiating;
    }

    private void StopInstantieting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartInstantiating()
    {
        _coroutine = StartCoroutine(Spawn());
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

            UnityEngine.GameObject gameObject = Instantiate(_templates[Random.Range(0, _templates.Length)],
                new Vector3(transform.position.x, positionY, transform.position.z), Quaternion.identity);

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