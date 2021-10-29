using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
	// Start is called before the first frame update
	private PlayerController player;
	private EventSystemCustom eventSystem;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		eventSystem = GameObject.Find("EventSystemCustom").GetComponent<EventSystemCustom>();
	}

	// when player eats the combo item
	public override void OnConsume()
	{
		player.playerHeartsCount -= 1;
		Debug.Log("HEART DECREASER ON CONSUME, count: " + player.playerHeartsCount.ToString());

		// invoke heart decrease to update hearts count
		eventSystem.OnHeartDecrease.Invoke();
	}
}


