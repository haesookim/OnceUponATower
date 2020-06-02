using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrbaekinteraction : NPCInteraction
{

	//트러플오일이 0, 사과가 1
	private bool[] itemsAdded = new bool[]{false, false};

	// Start is called before the first frame update

	void Start()
	{
		NPCName = "백종원";
		infoA = "백주부가 재료를 손질 중이다.";

		hasOptions = false;
		options = new List<string> {};

		Inventory = PlayerObject.GetComponent<PlayerInventory>();
		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}

	// Update is called once per frame
	void Update()
	{
		changeSprite();

		if (Inventory.contains("트러플 오일") && !itemsAdded[0]){
			hasOptions = true;
			addOption("트러플 오일을 건넨다.", "");
			//백종원 요리 애니메이션
			itemsAdded[0] = true;
		}

		if(Inventory.contains("사과") && !itemsAdded[1]){
			hasOptions = true;
			addOption("사과를 건넨다.", "에이 이건 맛이 없쥬~");
			itemsAdded[1] = true;


		}
	}



	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);

		if (optionNo == options.IndexOf("트러플 오일을 건넨다.")){
			Player.TriggerEnding(13);
			//animation
		}
		else if (optionNo == options.IndexOf("사과를 건넨다.")){
			return actionText[optionNo];

		}

		return null;
	}
}
