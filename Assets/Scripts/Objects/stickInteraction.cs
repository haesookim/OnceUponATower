using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stickInteraction : InteractableObject
{
	// Start is called before the first frame update

	public Sprite pieces;
	public bool optionselected = false;
	void Start()
	{
		itemName = "막대기";
		infoA = "단단한 막대기다.";
		infoB = "챙긴다.";

		hasOptions = true;
		options = new string[] { "부순다." };
		actionText = new string[] { "부서졌다. 나무조각을 얻었다." };
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	// Update is called once per frame
	void Update()
	{
		changeSprite();
	}

	public override string selectOption(int optionNo)
	{
		Inventory.replaceItem("나무조각", "단면이 날카로운 나무조각이다.", pieces);
		optionselected = true;
		this.GetComponent<SpriteRenderer>().enabled = false;
		return actionText[0];
	}
}
