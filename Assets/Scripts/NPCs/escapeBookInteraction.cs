﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeBookInteraction : NPCInteraction
{
	// Start is called before the first frame update

	public Canvas escapeBook;
	void Start()
	{
		NPCName = "탈출의 상식";
		infoA = "탈출의 상식이 가득 적혀있는 책이다.";

		hasOptions = true;
		options = new List<string> { "읽는다." };
		actionText = new List<string> { "모스 부호가 쓰여진 종이를 발견했다." };
		Player = PlayerObject.GetComponent<PlayerInteraction>();
	}

	public override string selectOption(int optionNo)
	{
		Player.dialogueActive = false;
		if (optionNo == 0)
		{
			escapeBook.gameObject.SetActive(true);
			//return actionText[0];
			//show morse code image;
		}
		return null;
	}

	void Update()
	{
		changeSprite();
	}
}
