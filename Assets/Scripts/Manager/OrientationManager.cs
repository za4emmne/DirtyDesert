using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class OrientationManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Murder _murder;
    [SerializeField] private float _offSet;
    [SerializeField] private float _offSetUI = 100;
    [SerializeField] private RectTransform _pauseButton;
    [SerializeField] private RectTransform _nameGame;
    [SerializeField] private RectTransform _score;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _floor;
    [SerializeField] private Transform _spawners;
    [SerializeField] private Transform _eagle;

    [SerializeField] private RectTransform _playButton;
    [SerializeField] private RectTransform _shopButton;
    [SerializeField] private RectTransform _settingButton;

    //private void Start()
    //{
    //    OnChanged();
    //}

    public void OnChanged()
    {
        if (Screen.width < Screen.height)
        {
            _eagle.localScale = new Vector3 (0.23f, 0.23f, 0);
            _camera.orthographicSize = 10f;
            _eagle.transform.position = new Vector3(_eagle.transform.position.x - _offSet-1, _eagle.transform.position.y - _offSet, _eagle.transform.position.z);
            ChangePosition(_spawners, _offSet);
            ChangePosition(_floor, _offSet);
            _murder.transform.position = new Vector3(_murder.transform.position.x - _offSet, _murder.transform.position.y - _offSet, _murder.transform.position.z);
            ChangePosition(_player.transform, _offSet * -1);

            ChangeUI(_score, _offSetUI);
            ChangeUI(_pauseButton, _offSetUI);
            ChangeUI(_nameGame, _offSetUI);

            _playButton.localScale = new Vector3 (2, 2, 0);
            _shopButton.localScale = new Vector3(2, 2, 0);
            _settingButton.localScale = new Vector3(2, 2, 0);
            ChangeUI(_playButton, -200);
            ChangeUI(_settingButton, 200);
        }
    }

    private void ChangeUI(RectTransform obj, float offset)
    {
        obj.anchoredPosition = new Vector2(obj.anchoredPosition.x, obj.anchoredPosition.y - offset);
    }
    private void ChangePosition(Transform obj, float offset)
    {
        obj.position = new Vector3(obj.position.x, obj.position.y - offset, obj.position.z);
    }
}
