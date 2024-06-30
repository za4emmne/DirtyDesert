using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killObj : MonoBehaviour
{
    [SerializeField] private PoolObjectTNT _poolObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TNT>(out TNT tnt))
        {
            _poolObject.PutObject(tnt);
        }

        if(collision.TryGetComponent<Object>(out Object obj))
        {
            Destroy(obj.gameObject);
        }
    }
}
