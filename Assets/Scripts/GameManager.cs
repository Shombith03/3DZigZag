using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private UIManager _uIManager;
    [SerializeField]
    private ScoreManager _scoreManager;
    [SerializeField]
    private PlatformSpawner _platformSpawner;

    internal bool gameOver;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void StartGame()
    {
        _uIManager.StartGame();
        //_scoreManager.StartScore();
        // start timer
        _platformSpawner.StartSpawningPlatforms();
    }

    public void GameOver()
    {
        _uIManager.GameOver();
        _scoreManager.StopScore();
        gameOver = true;
    }
}
