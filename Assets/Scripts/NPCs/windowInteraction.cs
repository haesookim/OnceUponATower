using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowInteraction : NPCInteraction
{
	private bool[] optionsAdded = new bool[] { false, false };
	private bool threadAdded = false;
	private bool droneOption = false;
	// Start is called before the first frame update
	void Start()
	{
		NPCName = "창문";
		infoA = "하늘이 화사하다.";

		hasOptions = true;
		options = new List<string> { "밖을 내다본다." };
		actionText = new List<string> { "창문 바깥으로 용이 보인다." };

		Inventory = PlayerObject.GetComponent<PlayerInventory>();
		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}

	// Update is called once per frame
	void Update()
	{
		changeSprite();
		if (Player.actionConditions[2])
		{
			actionText[0] = "창문 바깥으로 잠자는 용이 보인다.";
		}

		if (Inventory.contains("드론"))
		{
			if (!droneOption)
			{
				addOption("드론을 날린다.", "드론을 어떻게 날리는지 모르겠다.");
				droneOption = true;
			}
			if (Player.actionConditions[1])
			{
				actionText[options.IndexOf("드론을 날린다.")] = "잘 날아다닌다.";
			}
			if (Inventory.contains("사과즙"))
			{
				if (!optionsAdded[0])
				{
					addOption("드론으로 사과즙을 뿌린다.", "드론을 어떻게 날리는지 모르겠다.");
					optionsAdded[0] = true;
				}
			}
		}

		if (Inventory.contains("사과즙") && Inventory.contains("팅커벨"))
		{
			if (!optionsAdded[1])
			{
				addOption("팅커벨에게 사과즙을 넘긴다.", "");
				optionsAdded[1] = true;
			}
		}
		if (Inventory.contains("명주실") && !threadAdded)
		{
			addOption("명주실을 타고 내려간다.", "");
			threadAdded = true;
		}
	}

	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == 0)
		{
			return actionText[optionNo];
		}
		else if (optionNo == options.IndexOf("드론으로 사과즙을 뿌린다."))
		{
			if (Player.actionConditions[1])
			{
				Player.actionConditions[2] = true;
				Inventory.removeItem("사과즙");
				return "용이 코를 골며 잠들었다.";
			}
			else
			{
				return actionText[optionNo];
			}
		}
		else if (optionNo == options.IndexOf("팅커벨에게 사과즙을 넘긴다."))
		{
			Player.TriggerEnding(7);
			return null;
		}
		else if (optionNo == options.IndexOf("명주실을 타고 내려간다."))
		{
			Player.TriggerEnding(18);
			return null;
		}
		return null;
	}
}
