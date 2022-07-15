using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelGameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private TMP_Text _hightScoreText;
    [SerializeField] private Ball _ball;

    private const string _keyScore = "BestScore";

    private void Start()
    {
        Time.timeScale = 0;
        DisplayHightScore();
    }

    private void FixedUpdate()
    {
        _hightScoreText.text = PlayerPrefs.GetInt(_keyScore).ToString();
    }

    public void DisplayHightScore()
    {
        _pointText.text = _ball.Points.ToString();

        if (_ball.Points > PlayerPrefs.GetInt(_keyScore))
        {
            PlayerPrefs.SetInt(_keyScore, _ball.Points);
        }
    }
}
