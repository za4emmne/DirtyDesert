using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private Object _object;
    [SerializeField] private Transform _transform;

    private Queue<Object> _pool;

    public IEnumerable<Object> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Object>();
    }

    public Object GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_object);

            return obj;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Object obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
