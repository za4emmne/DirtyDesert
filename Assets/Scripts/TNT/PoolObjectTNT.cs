using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectTNT : MonoBehaviour
{
    [SerializeField] private TNT _bomb;
    [SerializeField] private Transform _transform;

    private Queue<TNT> _pool;

    public IEnumerable<TNT> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<TNT>();
    }

    public TNT GetObject()
    {
        if (_pool.Count == 0)
        {
            var tnt = Instantiate(_bomb);

            return tnt;
        }

        return _pool.Dequeue();
    }

    public void PutObject(TNT tnt)
    {
        _pool.Enqueue(tnt);
        tnt.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}