using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    internal int _scoreValue = 0;
    internal int _highestScore = 0;

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private Text _scoreText;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", _scoreValue);
    }

    public void IncrementScore()
    {
        _scoreValue += 1;
        _scoreText.text = _scoreValue.ToString(); 

        if(_scoreValue % 10 == 0)
        {
            //increment velocity
            _playerController._ballSpeed += 1;
        }
    }

    public void StopScore()
    {
        //CancelInvoke(nameof(IncrementScore));
        PlayerPrefs.SetInt("Score", _scoreValue);
        GameManager.Instance.StoreScore(_scoreValue);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore") < _scoreValue)
            {
                PlayerPrefs.SetInt("HighScore", _scoreValue);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", _scoreValue);
        }
    }
}
