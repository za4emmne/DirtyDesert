using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class PlayerMovenment : MonoBehaviour
{
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    [SerializeField] private float _jumpForce = 500;
    [SerializeField] private ParticleSystem _dust;

    private Rigidbody2D _rigidbody2D;
    private bool _isGround;
    private AudioSource _audio;

    public event Action AnimationJumpPlayed;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)/* || Input.touchCount == 1*/)
            Jump();
    }

    private void OnEnable()
    {
        _playerBoomTNT.PlayerBoomed += AddForce;
    }

    private void OnDisable()
    {
        _playerBoomTNT.PlayerBoomed -= AddForce;
    }

    public void AddJumpForce(float addJumpForce)
    {
        _jumpForce += addJumpForce;
    }

    public void Jump()
    {
        if (_isGround)
        {
            AnimationJumpPlayed?.Invoke();
            //_dust.Play();
            AddForce();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = true;
            _audio.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Flour flour))
        {
            _isGround = false;
        }
    }

    private void AddForce()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
