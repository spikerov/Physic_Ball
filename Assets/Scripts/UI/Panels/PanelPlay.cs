using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        _placeChoiceDirection.gameObject.SetActive(true);
        _hightScoreText.text = PlayerPrefs.GetInt(_keyScore).ToString();
        Time.timeScale = 1;
    }

    private void PointView(int point)
    {
        _textPoints.text = point.ToString();
    }
}
