using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovenment : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    public float Speed => _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * -1, 0, 0, Space.Self);
    }
}
