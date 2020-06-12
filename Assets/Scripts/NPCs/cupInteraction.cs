using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupInteraction : NPCInteraction
{
	public bool[] itemsAdded = new bool[] { false, false, false };
	void Start()
	{
		NPCName = "컵";
		infoA = "액체를 담아 마실 수 있는 컵이다.";
		hasOptions = false;

		options = new List<string> { };
		actionText = new List<string> { };

		Player = PlayerObject.GetComponent<PlayerInteraction>();
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	// Update is called once per frame
	void Update()
	{
		changeSprite();
		if (Inventory.contains("사과즙") && !itemsAdded[0])
		{
			addOption("사과즙을 마신다.", "");
			itemsAdded[0] = true;
			hasOptions = true;
		}
		if (Inventory.contains("독극물") && !itemsAdded[1])
		{
			addOption("독극물을 마신다.", "몸이 작아졌다");
			itemsAdded[1] = true;
			hasOptions = true;
		}
		if (Inventory.contains("스테로이드") && !itemsAdded[2])
		{
			addOption("스테로이드를 마신다.", "힘이 나는 기분이다");
			itemsAdded[2] = true;
			hasOptions = true;
		}
	}

	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == options.IndexOf("사과즙을 마신다."))
		{ // is applejuice
			Player.TriggerEnding(15);
			return null;
		}
		else if (optionNo == options.IndexOf("독극물을 마신다."))
		{ // is poison
			Player.actionConditions[6] = true;

			//change sprite to tiny princess
			PlayerObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		}
		else if (optionNo == options.IndexOf("스테로이드를 마신다."))
		{ // is steroid
			Player.actionConditions[7] = true;
		}
		return actionText[optionNo];
	}
}
