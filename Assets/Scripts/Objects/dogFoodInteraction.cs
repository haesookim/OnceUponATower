using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogFoodInteraction : InteractableObject
{
	// Start is called before the first frame update
	private int eatCount = 0;

	void Start()
	{
		itemName = "사료";
		infoA = "멍멍이가 먹을 거 같은 사료다.";
		infoB = "챙긴다.";

		hasOptions = true;
		options = new string[] { "먹는다." };
		actionText = new string[] { "생각보다 맛있다." };

		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}

	void Update()
	{
		changeSprite();
	}

	public override string selectOption(int optionNo)
	{
		eatCount++;
		if (eatCount > 4)
		{
			Player.TriggerEnding(24);
		}
		return actionText[0];
	}
}
