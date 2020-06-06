using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementInteraction : NPCInteraction
{
	void Start()
	{
		NPCName = "공주들";
		infoA = "수백만명의 공주들이 울고 있다.";

		hasOptions = true;
		options = new List<string> { "탈출시킨다!" };
		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}
	public override string selectOption(int optionNo)
	{
		Player.TriggerEnding(9);
		return null;
	}
}
