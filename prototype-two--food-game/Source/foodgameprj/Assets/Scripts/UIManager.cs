using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text scoreText;
	public EventSystemCustom eventSystem;

	void Start()
	{
		eventSystem.OnScoreIncrease.AddListener(UpdateScoreText);
	}

	public void UpdateScoreText()
	{
		Debug.Log("update score");

		// find the playerScore that is recorded in playerController script
		var player = GameObject.Find("Player").GetComponent<PlayerController>();
		scoreText.text = player.playerScore.ToString();

	}

}
