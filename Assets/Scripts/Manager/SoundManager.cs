using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _backgroundMusic;
    [SerializeField] private AudioClip _boom;
    [SerializeField] private AudioClip _coinSound;

    private int _soundCount;

    private void Awake()
    {
                _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        

        _soundCount = Random.Range(0, _backgroundMusic.Length);
        _audioSource.clip = _backgroundMusic[_soundCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
