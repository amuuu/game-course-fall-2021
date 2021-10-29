using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text scoreText;
	public Text heartText;
	public EventSystemCustom eventSystem;
	private PlayerController player;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		heartText.text = player.playerHeartsCount.ToString();

		eventSystem.OnScoreIncrease.AddListener(UpdateScoreText);
		eventSystem.OnHeartDecrease.AddListener(UpdateHeartCountText);
		eventSystem.OnHeartIncrease.AddListener(UpdateHeartCountText);
		eventSystem.OnLooseCondition.AddListener(UpdateLooseText);
	}

	public void UpdateScoreText()
	{
		Debug.Log("update score");
		// find the playerScore that is recorded in playerController script
		scoreText.text = player.playerScore.ToString();
	}

	public void UpdateHeartCountText()
	{
		Debug.Log("update hearts count");
		heartText.text = player.playerHeartsCount.ToString();
	}

	public void UpdateLooseText()
	{
		heartText.text = "YOU LOST!";
		Time.timeScale = 0;
	}

}
