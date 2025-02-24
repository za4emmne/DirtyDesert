using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class PlayerMovenment : MonoBehaviour
{
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;
    //[SerializeField] private float _jumpForce = 500;
    [SerializeField] private ParticleSystem _dust;

    private float _jumpHeight = 3f; // Высота прыжка
    private float _jumpDuration = 1f; // Время прыжка

    private float _jumpSpeed; // Начальная скорость прыжка
    private float _gravity; // Гравитация
    private bool _isJumping = false;
    private float _jumpStartTime;
    private float _initialY; // Начальная высота игрока

    private Rigidbody2D _rigidbody2D;
    private bool _isGround;
    private AudioSource _audio;

    public event Action<bool> AnimationJumpPlayed;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // Рассчитываем начальную скорость и гравитацию
        _gravity = (8f * _jumpHeight) / (_jumpDuration * _jumpDuration);
        _jumpSpeed = (4f * _jumpHeight) / _jumpDuration;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)/* || Input.touchCount == 1*/)
        //    Jump();

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            StartJump();

        }

        if (_isJumping)
        {
            HandleJump();
        }

        AnimationJumpPlayed?.Invoke(_isGround);
    }

    public void ChangeTimeJump()
    {
        _jumpDuration -= 0.05f;
        _gravity = (8f * _jumpHeight) / (_jumpDuration * _jumpDuration);
        _jumpSpeed = (4f * _jumpHeight) / _jumpDuration;
    }

    private void StartJump()
    {
        _isJumping = true;
        _jumpStartTime = Time.time;
        _initialY = transform.position.y; // Запоминаем начальную высоту
    }

    public void HandleJump()
    {
        float elapsedTime = Time.time - _jumpStartTime;

        if (elapsedTime < _jumpDuration)
        {
            // Рассчитываем текущую высоту по параболической формуле
            float y = _initialY + _jumpSpeed * elapsedTime - 0.5f * _gravity * elapsedTime * elapsedTime;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        else
        {
            // Завершаем прыжок
            _isJumping = false;
            transform.position = new Vector3(transform.position.x, _initialY, transform.position.z); // Возвращаем игрока на землю
        }
    }


    //private void OnEnable()
    //{
    //    _playerBoomTNT.PlayerBoomed += AddForce;
    //}

    //private void OnDisable()
    //{
    //    _playerBoomTNT.PlayerBoomed -= AddForce;
    //}

    //public void AddJumpForce(float addJumpForce)
    //{
    //    _jumpForce += addJumpForce;
    //}

    //public void Jump()
    //{
    //    if (_isGround)
    //    {
    //        AnimationJumpPlayed?.Invoke();
    //        //_dust.Play();
    //        AddForce();
    //    }

    //}

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

    //private void AddForce()
    //{
    //    //_rigidbody2D.AddForce(Vector2.up * _jumpForce);
    //    transform.Translate(new Vector3(0, 200, 0) * Time.deltaTime);
    //}
}
