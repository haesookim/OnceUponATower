using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : NPCInteraction
{

	private bool[] optionsAdded = new bool[] { false, false, false };
	public int fireNo;
	public int fireState = 0;

	public Sprite fire00A;
	public Sprite fire00B;
	public Sprite fire00C;

	Animator animator;
	// Start is called before the first frame update
	void Start()
	{
		NPCName = "횃불";
		hasOptions = false;
		optionsVisible = true;


		Player = PlayerObject.GetComponent<PlayerInteraction>();
		Inventory = PlayerObject.GetComponent<PlayerInventory>();
		options = new List<string> { "" };
		animator = gameObject.GetComponent<Animator>();



	}

	// Update is called once per frame
	void Update()
	{
		if (Inventory.contains("성냥")){
			hasOptions = true;
		}
		if(Player.fireConditions[100]==1 && Player.fireConditions[101]==1 && Player.fireConditions[102]==1 && Player.fireConditions[103]==0 && Player.fireConditions[104]==0){
			if(Player.fireConditions[110]==2 && Player.fireConditions[111]==2 && Player.fireConditions[112]==2 && Player.fireConditions[113]==0 && Player.fireConditions[114]==0){
				if(Player.fireConditions[120]==1 && Player.fireConditions[121]==1 && Player.fireConditions[122]==1 && Player.fireConditions[123]==0 && Player.fireConditions[124]==0){
					Player.TriggerEnding(14);
				}
			}

		}



	}


	public override string selectOption(int optionNo)
	{
		Debug.Log("?");

		if (fireState == 0)
		{
			fireState = 1;
			Player.fireConditions[fireNo] = 1;
		}

		else if (fireState == 1)
		{
			fireState = 2;
			Player.fireConditions[fireNo] = 2;
		}
		else if (fireState == 2)
		{
			fireState = 0;
			Player.fireConditions[fireNo] = 0;
		}
		animator.SetInteger("FireState", fireState);

		return null;
	}


}
