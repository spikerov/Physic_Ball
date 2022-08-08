using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using InstantGamesBridge;

public class PanelPlay : MonoBehaviour
{
    [SerializeField] private PlaceChoiceDirection _placeChoiceDirection;
    [SerializeField] private TMP_Text _hightScoreText;
    [SerializeField] private TMP_Text _textPoints;
    [SerializeField] private Ball _ball;

    private const string _keyScore = "BestScore";

    private void OnEnable()
    {
        _ball.ChangedPoint += PointView;
    }

    private void OnDisable()
    {
        _ball.ChangedPoint -= PointView;
    }

    private void Start()
    {
        Bridge.game.GetData(_keyScore, (success, data) =>
        {
            if (success)
            {
                _hightScoreText.text = data;
            }
            else
            {
                Debug.Log("Score Data Error");
            }
        });

        Time.timeScale = 1;
        _placeChoiceDirection.gameObject.SetActive(true);
    }

    private void PointView(int point)
    {
        _textPoints.text = point.ToString();
    }
}
