using UnityEngine;

[RequireComponent(typeof(GameManager))]

public class MovementManager : MonoBehaviour
{  
    private GameManager _gameManager;
    private Object[] _objects;
    private float _speed;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        _objects = FindObjectsOfType<Object>();
        _speed = _gameManager.Speed;

        foreach (var obj in _objects)
        {
            obj.transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}
