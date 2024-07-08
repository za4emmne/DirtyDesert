using System.Collections.Generic;
using UnityEngine;

public class PoolObjectCactus : MonoBehaviour
{
    [SerializeField] private Cactus _object;
    [SerializeField] private Transform _transform;

    private Queue<Cactus> _pool;

    public IEnumerable<Cactus> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Cactus>();
    }

    public Cactus GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_object);

            return obj;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Cactus obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
