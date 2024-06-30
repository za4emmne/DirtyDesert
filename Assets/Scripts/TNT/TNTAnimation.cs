using UnityEngine;

public class TNTAnimation : MonoBehaviour
{
    private const string AnimationNameBoom = "Boom";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            BoomAnimationPlayed();
            Destroy(this.gameObject, 0.5f);
        }
    }

    private void BoomAnimationPlayed()
    {
        _animator.SetTrigger(AnimationNameBoom);
    }
}
