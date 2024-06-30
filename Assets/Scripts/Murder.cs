using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 5;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out MurderTarget murderTarget))
        {
            this.gameObject.SetActive(false);
        }
    }
}
