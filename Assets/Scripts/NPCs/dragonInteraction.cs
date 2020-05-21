using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonInteraction : NPCInteraction
{
	private bool isSleeping;
	private bool[] conditionList = new bool[]{false, false};
	void Start(){
		NPCName = "용";

		infoA = "용이다";

		hasOptions = true;

		options = new List<string>{"용에게 맞선다."};

		Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	void Update(){
		if (!isSleeping){ 
			if (Player.actionConditions[2]){
				isSleeping = true;
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				gameObject.GetComponent<Animator>().enabled = true;
				gameObject.transform.position -= new Vector3(0, 0.17f, 0);
				hasOptions = false;
			}

			if (Inventory.contains("사과즙")){
				if(Inventory.contains("드론") && !conditionList[0]){
					addOption("드론으로 사과즙을 뿌린다.", "드론을 어떻게 날리는지 모르겠다.");
					conditionList[0]=true;
				}
				if (Inventory.contains("팅커벨") && !conditionList[1]){
					addOption("팅커벨에게 사과즙을 부탁한다.", "");
					conditionList[0] = true;
				}
			}
		}
	}

	public override string selectOption(int optionNo){
		Player.optionsBox.SetActive(false);
		if(optionNo == 0){
			Player.TriggerEnding(6);
			return null;
		} else if (optionNo == options.IndexOf("드론으로 사과즙을 뿌린다.")){
			if (Player.actionConditions[1]){
				Player.TriggerEnding(5);
				return null;
			} else {
				Player.TriggerEnding(6);
				return actionText[optionNo];
			}
		} else if (optionNo == options.IndexOf("팅커벨에게 사과즙을 부탁한다.")){
			Player.TriggerEnding(7);
			return null;
		}
		return null;
	}
}
