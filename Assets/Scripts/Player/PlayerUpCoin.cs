using System;
using UnityEngine;

public class PlayerUpCoin : MonoBehaviour
{ 
    [SerializeField] private AudioClip _coinSound;

    public event Action UpCoin;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            UpCoin?.Invoke();
            _audioSource.PlayOneShot(_coinSound);
            Destroy(coin.gameObject, 0.05f);
        }
    }
}
