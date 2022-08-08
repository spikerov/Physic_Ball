using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using InstantGamesBridge;
using System;

public class PanelGameOver : MonoBehaviour
{
    [SerializeField] private ShowAdvertising _advertising;
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private TMP_Text _hightScoreText;
    [SerializeField] private Ball _ball;

    private const string _keyScore = "BestScore";

    private void Start()
    {

        Time.timeScale = 0;
        _advertising.ShowingAdvertising();

        DisplayHightScore();

        Bridge.game.GetData(_keyScore, (success, data) =>
        {
            if (success)
            {
                if (_ball.Points > Convert.ToInt32(data))
                {
                    Bridge.game.SetData(_keyScore, _ball.Points.ToString());
                    _hightScoreText.text = _ball.Points.ToString();
                }
                else
                {
                    _hightScoreText.text = data;
                }
            }
            else
            {
                Debug.Log("Score Data Error");
            }
        });
    }

    public void DisplayHightScore()
    {
        _pointText.text = _ball.Points.ToString();
    }
}
