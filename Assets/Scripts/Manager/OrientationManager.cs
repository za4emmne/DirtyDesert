using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class OrientationManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Murder _murder;
    [SerializeField] private float _offSet;
    [SerializeField] private RectTransform _pauseButton;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _floor;
    [SerializeField] private Transform _spawners;
    [SerializeField] private Transform _eagle;

    //private void Start()
    //{
    //    OnChanged();
    //}

    public void OnChanged()
    {
        if (Screen.width < Screen.height)
        {
            _camera.orthographicSize = 10f;
            ChangePosition(_eagle, _offSet);
            ChangePosition(_spawners, _offSet);
            ChangePosition(_floor, _offSet);
            _murder.transform.position = new Vector3(_murder.transform.position.x - _offSet, _murder.transform.position.y - _offSet, _murder.transform.position.z);
            ChangePosition(_player.transform, _offSet * -1);

            _pauseButton.anchoredPosition = new Vector2(_pauseButton.anchoredPosition.x, _pauseButton.anchoredPosition.y - 100);
        }
    }

    private void ChangePosition(Transform obj, float offset)
    {
        obj.position = new Vector3(obj.position.x, obj.position.y - offset, obj.position.z);
    }
}
