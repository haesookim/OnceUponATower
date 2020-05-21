using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleinteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "사과";
        infoA = "탐스러운 사과다. 조금 수상하다.";
        infoB = "챙긴다";

        hasOptions = true;
        options = new string[]{"먹는다"};
        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update(){
        changeSprite();
    }
    
    public override string selectOption(int optionNo){
        Player.TriggerEnding(1);
        return null;
    }
}
