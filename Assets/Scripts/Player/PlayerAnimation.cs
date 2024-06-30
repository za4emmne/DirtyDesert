using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private const string AnimationNameRun = "Speed";
    private const string AnimationNameJump = "Jump";
    private const string AnimationNameDead = "Dead";

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerMovenment _playerJumping;
    [SerializeField] private PlayerBoomTNT _playerBoomTNT;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
    }

    private void OnEnable()
    {
        _playerJumping.AnimationJumpPlayed += Jump;
        _playerBoomTNT.PlayerBoomed += Dead;
    }

    private void OnDisable()
    {
        _playerJumping.AnimationJumpPlayed -= Jump;
        _playerBoomTNT.PlayerBoomed -= Dead;
    }

    private void Jump()
    {
        _animator.SetTrigger(AnimationNameJump);
    }

    private void Run()
    {
        _animator.SetFloat(AnimationNameRun, _gameManager.Speed);
    }

    private void Dead()
    {
        _animator.SetBool(AnimationNameDead, true);
    }
}
