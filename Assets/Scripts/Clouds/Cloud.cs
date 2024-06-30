using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private Transform _spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<killObj>(out killObj killer))
        {
            transform.position = _spawner.position;
            gameObject.SetActive(false);
        }
    }
}
