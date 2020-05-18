using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portraitInteraction : NPCInteraction
{
    // Start is called before the first frame update
    public Sprite steroidSprite;
    public bool hasSteroid;
    void Start()
    {
        NPCName = "수상한 초상화";
        hasOptions = true;

        Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
        options = new List<string>{" "};
        actionText = new List<string>{"『받으렴.』"};
    }

    public override string selectOption(int optionNo){
        Player.dialogueCanvas.gameObject.SetActive(true);
        GameObject.Find("ObjName").GetComponent<Text>().text = NPCName;
        Inventory.replaceItem("스테로이드", "수상한 초상화가 건내준 스테로이드다.", steroidSprite);
        hasOptions = false;
        return actionText[optionNo];
    }
}
