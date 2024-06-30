using System.Collections;
using UnityEngine;

public class CloudsInstantiates : MonoBehaviour
{
    [SerializeField] private Cloud[] _clouds;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _devationPositionY = 0;

    private float _spawnTime;
    private int _randomNumber;

    private void Awake()
    {
        for (int i = 0; i < _clouds.Length; i++)
        {
            _clouds[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY;
        float maxPositionY = transform.position.y + _devationPositionY;

        while (true)
        {
            float positionY = Random.Range(minPositionY, maxPositionY);
            _spawnTime = Random.Range(_minDelay, _maxDelay);
            _randomNumber = Random.Range(0, _clouds.Length);
            var waitForSeconds = new WaitForSeconds(_spawnTime);

            Cloud cloud = _clouds[_randomNumber];

            if (cloud.gameObject.activeInHierarchy == false)
            {
                cloud.gameObject.SetActive(true);
                cloud.transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
            }
            else
                _randomNumber = Random.Range(0, _clouds.Length);

            yield return waitForSeconds;
        }
    }
}
