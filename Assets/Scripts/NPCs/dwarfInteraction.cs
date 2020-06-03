using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwarfInteraction : NPCInteraction
{
	// Start is called before the first frame update
	void Start()
	{
		NPCName = "난쟁이";
		infoA = "어디에선가 본 것 같은 난쟁이가..";

		hasOptions = false; ;

		options = new List<string> { "따라간다." };
		actionText = new List<string> { " " };

		Player = PlayerObject.GetComponent<PlayerInteraction>();
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Player.actionConditions[3])
		{
			infoA = "잘생긴 나의 난쟁이...";
			hasOptions = true;
		}
	}

	public override string selectOption(int optionNo)
	{
		if (optionNo == 0)
		{
			Player.TriggerEnding(12);
		}
		return null;
	}

}
