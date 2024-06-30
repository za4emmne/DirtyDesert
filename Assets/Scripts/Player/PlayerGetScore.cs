using System;
using UnityEngine;

public class PlayerGetScore : MonoBehaviour
{
    public event Action PlayerGetedScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TNTTrigger tnt))
        {
            PlayerGetedScore?.Invoke();
        }
    }
}
