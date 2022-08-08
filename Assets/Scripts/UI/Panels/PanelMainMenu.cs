using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using InstantGamesBridge;

public class PanelMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _hightScoreText;

    private const string _keyScore = "BestScore";

    private void Start()
    {
        Time.timeScale = 0;

		Bridge.game.GetData(_keyScore, (success, data) =>
		{
			if (success)
			{
				if (data == null)
				{
					Bridge.game.SetData(_keyScore, "0");
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
}
