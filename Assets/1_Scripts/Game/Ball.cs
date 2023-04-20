using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GameManager _gameManager;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(Vector2 direction)
    {
        _rigidbody.AddForce(direction.normalized * _force);
        _gameManager.AddScore();
    }
    
    private void Update()
    {
        if(_gameManager.IsGameOver()) return;
        
        if(transform.position.x < DisplayManager.LeftX || transform.position.x > DisplayManager.RightX ||
           transform.position.y < DisplayManager.BottomY || transform.position.y > DisplayManager.TopY)
            _gameManager.GameOver(true);
    }
}
