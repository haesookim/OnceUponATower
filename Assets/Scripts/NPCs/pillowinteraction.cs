using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowinteraction : NPCInteraction
{
	// Start is called before the first frame update
	void Start()
	{
		NPCName = "베개";
		infoA = "푹신한 베개다.";

		hasOptions = true;
		options = new List<string> { "베개를 베고 눕는다." };

		actionText = new List<string> { "" };
		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}


	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == 0)
		{
			Player.TriggerEnding(20);
		}
		return null;
	}


	void Update()
	{
		changeSprite();
	}

}
