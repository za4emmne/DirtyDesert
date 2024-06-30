using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObjectCloud : MonoBehaviour
{
    [SerializeField] private Cloud[] _clouds;
    [SerializeField] private Transform _transform;

    private Queue<Cloud> _pool;
    private int _numberCloud = 0;

    public IEnumerable<Cloud> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Cloud>();
    }

    public Cloud GetObject()
    {
        if (_pool.Count == 0)
        {
            var cloud = Instantiate(_clouds[_numberCloud]);
            _numberCloud++;

            if(_numberCloud == _clouds.Length)
            {
                _numberCloud = 0;
            }

            return cloud;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Cloud cloud)
    {
        _pool.Enqueue(cloud);
        cloud.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
