using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killObj : MonoBehaviour
{
    [SerializeField] private PoolObjectTNT _poolObject;
    [SerializeField] private PoolObjectStone _stone;
    [SerializeField] private PoolObjectCactus _cactus;
    [SerializeField] private PoolObjectCoin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TNT>(out TNT tnt))
        {
            _poolObject.PutObject(tnt);
        }

        if (collision.TryGetComponent<Stone>(out Stone stone))
        {
            _stone.PutObject(stone);
        }

        if (collision.TryGetComponent<Cactus>(out Cactus cactus))
        {
            _cactus.PutObject(cactus);
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coin.PutObject(coin);
        }

        if (collision.TryGetComponent<Object>(out Object obj))
        {
            //Destroy(obj.gameObject);
            obj.gameObject.SetActive(false);
        }
    }
}