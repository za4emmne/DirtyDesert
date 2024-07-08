using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Murder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Text _dialog;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _speed = 5;
    [SerializeField] private string[] _dialogText;

    private string _dialogStartGame = "Попробуй поймать меня";

    private void Start()
    { 
        int number = Random.Range(0, _dialogText.Length);
        _dialog.text = _dialogText[number];
    }

    private void OnEnable()
    {
        _gameManager.Play += StartGame;
    }
    private void OnDisable()
    {
        _gameManager.Play -= StartGame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out MurderTarget murderTarget))
        {
            gameObject.SetActive(false);
        }
    }

    private void StartGame()
    {
        _dialog.text = _dialogStartGame;
        StartCoroutine(GetAway());
    }

    private IEnumerator GetAway()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        yield return null;
    }
}
