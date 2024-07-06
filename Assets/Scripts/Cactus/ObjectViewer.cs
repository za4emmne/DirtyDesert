using UnityEngine;

public class ObjectViewer : MonoBehaviour
{
    [SerializeField] private Template _object;
    [SerializeField] private SpriteRenderer _image;
    private int _randomNumber;

    private void Start()
    {
        _image = GetComponent<SpriteRenderer>();
        _randomNumber = Random.Range(0, 4);
        _image.sprite = _object.Sprites[_randomNumber];
    }
}
