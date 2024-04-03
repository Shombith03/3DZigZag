using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private GameObject _startPanel;
    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private Text _tapToStartText;
    [SerializeField] private Text _score;

    [SerializeField]
    private Text _highScoreText;
    [SerializeField]
    private Text _bestScoreText;

    private bool startTimer = false;
    private float timer;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Text _totalTimeTaken;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _bestScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        if(startTimer)
        {
            timer += Time.deltaTime;

            ShowTimerText(_timerText);
        }
    }

    public void StartGame()
    {
        _tapToStartText.gameObject.SetActive(false);
        _startPanel.GetComponent<Animator>().Play("PanelOut");
        startTimer = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        startTimer = false;
        _score.text = PlayerPrefs.GetInt("Score").ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        ShowTimerText(_totalTimeTaken);
        _gameOverPanel.SetActive(true);
    }

    private void ShowTimerText(Text text)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
