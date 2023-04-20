using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _effectClick;
    [SerializeField] private GameManager _gameManager;

    private float _currentTime;
    private bool _mayJump;

    [SerializeField] private AudioClip _click;

    private void Update()
    {
        if (_gameManager.IsPaused()) return; 
        if (_currentTime >= _time) _mayJump = true;
        else _currentTime += Time.deltaTime;
        
        if (Input.GetMouseButtonUp(0) && _mayJump)
        {
            var mousePos = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(_effectClick, mousePos, Quaternion.identity);
            var direction = (Vector2) transform.position - mousePos;
            _ball.Jump(direction);
            _mayJump = false;
            _currentTime = 0;
            AudioManager.getInstance().PlayAudio(_click);
        }
    }
}
