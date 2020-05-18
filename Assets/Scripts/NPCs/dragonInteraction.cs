using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonInteraction : NPCInteraction
{
	public bool isSleeping;
    void Start(){
		NPCName = "용";

		Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
	}

	void Update(){
		if (!isSleeping && Player.actionConditions[2]){
			isSleeping = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
