using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TopScores _topScores;

    [Header("UI")] 
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _scoreText;

    [Header("Audio")] 
    [SerializeField] private AudioClip _gameOverClip;

    private int _score;

    public bool IsGameOver()
    {
        return _gameOverPanel.activeSelf;
    }
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        Pause(false);
        GameOver(false);
    }
    
    public void GameOver(bool gameOver)
    {
        _gameOverPanel.SetActive(gameOver);
        if (gameOver)
        {
            _topScores.Scores.Add(_score);
            AudioManager.getInstance().PlayAudio(_gameOverClip);
        }
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        _pausePanel.SetActive(pause);
    }
    
    public bool IsPaused()
    {
        return _pausePanel.activeSelf;
    }
}
