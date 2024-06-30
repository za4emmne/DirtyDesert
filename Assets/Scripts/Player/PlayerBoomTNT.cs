using UnityEngine;
using System;

public class PlayerBoomTNT : MonoBehaviour
{
    [SerializeField] private AudioClip _boomSound;

    public event Action PlayerBoomed;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TNT tnt))
        {
            PlayerBoomed?.Invoke();
            _audioSource.PlayOneShot(_boomSound);
        }
    }
}
