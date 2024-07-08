using System.Collections.Generic;
using UnityEngine;

public class PoolObjectCoin : MonoBehaviour
{
    [SerializeField] private Coin _object;
    private Transform _transform;

    private Queue<Coin> _pool;

    public IEnumerable<Coin> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Coin>();
        _transform = GetComponent<Transform>();
    }

    public Coin GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_object);

            return obj;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Coin obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
