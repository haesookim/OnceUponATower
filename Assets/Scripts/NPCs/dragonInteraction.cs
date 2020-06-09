using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonInteraction : NPCInteraction
{
	private bool isSleeping;
	private bool[] conditionList = new bool[] { false, false, false, false };
	public Sprite sleeping_H;
	void Start()
	{
		NPCName = "용";

		infoA = "용이다";

		hasOptions = true;

		options = new List<string> { "용에게 맞선다.", "왕자에게 도움을 청한다." };

		Player = PlayerObject.GetComponent<PlayerInteraction>();
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	void Update()
	{
		changeSprite();

		if (!isSleeping)
		{
			if (Player.actionConditions[2])
			{
				isSleeping = true;
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				gameObject.GetComponent<Animator>().SetBool("dragonsleeping", true);
				//activeSprite = sleeping_H;
				gameObject.transform.position -= new Vector3(0, 0.17f, 0);
				hasOptions = false;
			}

			if (Inventory.contains("사과즙"))
			{
				if (Inventory.contains("드론") && !conditionList[0])
				{
					addOption("드론으로 사과즙을 뿌린다.", "드론을 어떻게 날리는지 모르겠다.");
					conditionList[0] = true;
				}
				if (Inventory.contains("팅커벨") && !conditionList[1])
				{
					addOption("팅커벨에게 사과즙을 부탁한다.", "");
					conditionList[1] = true;
				}
			}
			if (Inventory.contains("막대기") && !conditionList[2])
			{
				addOption("막대기로 찌른다.", "죽어라");
				conditionList[2] = true;
			}
			if (Inventory.contains("스테로이드") && !conditionList[3])
			{
				addOption("스테로이드를 준다.", "용에게 이정도 복용량은 아무 소용이 없다. 용이 실망한 눈치다.");
				conditionList[3] = true;

			}
		}
	}

	public override string selectOption(int optionNo)
	{
		Player.optionsBox.SetActive(false);
		if (optionNo == 0)
		{
			Player.TriggerEnding(6);
			return null;
		}
		else if (optionNo == 1)
		{
			Player.TriggerEnding(8);
			return @"『공주님! 무사하셨군요. 아아… 정말 다행입니다.
						용맹한 제가 용을 무찔렀어요. 이제 안심하셔도 됩니다.
						일단 이곳을 빠져나가요. 맥시무스, 공주님을 도와드려.』";

		}
		else if (optionNo == options.IndexOf("드론으로 사과즙을 뿌린다."))
		{
			if (Player.actionConditions[1])
			{
				Player.TriggerEnding(5);
				return null;
			}
			else
			{
				Player.TriggerEnding(6);
				return actionText[optionNo];
			}
		}
		else if (optionNo == options.IndexOf("팅커벨에게 사과즙을 부탁한다."))
		{
			Player.TriggerEnding(7);
			return null;
		}
		else if (optionNo == options.IndexOf("막대기로 찌른다."))
		{
			Player.TriggerEnding(25);
			return null;
		}
		else if (optionNo == options.IndexOf("스테로이드를 준다."))
		{
			Player.TriggerEnding(26);
			return null;
		}
		return null;
	}
}
