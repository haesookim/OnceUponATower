﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doginteraction : NPCInteraction
{
	public Sprite mushroomSprite;
	private bool[] optionsAdded = new bool[] { false, false };

	private int petCount = 0;
	// Start is called before the first frame update
	void Start()
	{
		NPCName = "멍멍이";
		infoA = "귀여운 멍멍이다. 쓰다듬고 싶다.";

		hasOptions = true;
		options = new List<string> { "쓰다듬는다." };
		actionText = new List<string> { "『멍- 멍!』" };

		Inventory = PlayerObject.GetComponent<PlayerInventory>();
		Player = PlayerObject.GetComponent<PlayerInteraction>();

	}

	// Update is called once per frame
	void Update()
	{
		changeSprite();
		if (Inventory.contains("사료"))
		{
			if (!optionsAdded[0])
			{
				addOption("사료를 먹인다.", "");
				optionsAdded[0] = true;
			}
		}
		if (Inventory.contains("사과"))
		{
			if (!optionsAdded[1])
			{
				addOption("사과를 먹인다.", "");
				optionsAdded[1] = true;
			}
		}
	}

	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == 0)
		{
			petCount++;
			if (petCount > 9)
			{
				Player.TriggerEnding(23);
			}
			return actionText[optionNo];
		}
		if (optionNo == options.IndexOf("사료를 먹인다."))
		{
			Inventory.removeItem("사료");
			Inventory.replaceItem("송로버섯", "자연산 송로버섯이다. 멍멍이가 파주었다...", mushroomSprite);
			options.RemoveAt(optionNo);
			actionText.RemoveAt(optionNo);
			return "멍멍이가 송로버섯을 찾았다.";
		}
		if (optionNo == options.IndexOf("사과를 먹인다."))
		{
			Player.TriggerEnding(22);
		}
		return null;
	}
}
