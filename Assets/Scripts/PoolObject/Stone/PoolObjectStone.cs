using System.Collections.Generic;
using UnityEngine;

public class PoolObjectStone : MonoBehaviour
{
    [SerializeField] private Stone _object;
    [SerializeField] private Transform _transform;

    private Queue<Stone> _pool;

    public IEnumerable<Stone> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Stone>();
    }

    public Stone GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_object);

            return obj;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Stone obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}