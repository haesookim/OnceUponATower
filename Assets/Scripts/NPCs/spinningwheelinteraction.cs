using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningwheelinteraction : NPCInteraction
{
	public bool itemAdded = false;
	public Sprite thread;
	// Start is called before the first frame update

	void Start()
	{
		NPCName = "물레";
		infoA = "표면이 거친 물레다.";

		hasOptions = true;
		options = new List<string> { "살펴본다." };
		actionText = new List<string> { "아얏!!!" };

		Player = PlayerObject.GetComponent<PlayerInteraction>();
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}


	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == 0)
		{
			Player.TriggerEnding(21);
			return null;
		}
		if (optionNo == 1)
		{
			Inventory.removeItem("누에고치");
			Inventory.replaceItem("명주실", "누에고치에서 뽑아낸 명주실이다.", thread);
			options.Remove("고치로 실을 뽑는다.");
			return actionText[optionNo];

		}
		return null;
	}


	void Update()
	{
		changeSprite();
		if (Inventory.contains("누에고치") && !itemAdded)
		{
			addOption("고치로 실을 뽑는다.", "윤기가 자르르한 명주실이 만들어졌다.\n마치… 라푼젤의 머리 같다.");
			itemAdded = true;
		}

	}
}
