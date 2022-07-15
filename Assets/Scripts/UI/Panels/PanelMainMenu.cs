using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _hightScoreText;

    private const string _keyScore = "BestScore";

    private void Start()
    {
        Time.timeScale = 0;

        if (PlayerPrefs.HasKey(_keyScore) == false)
            PlayerPrefs.SetInt(_keyScore, 0);

        _hightScoreText.text = PlayerPrefs.GetInt(_keyScore).ToString();
    }

    private void Update()
    {
        
    }
}
