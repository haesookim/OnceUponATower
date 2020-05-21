using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupInteraction : NPCInteraction
{
    public bool[] itemsAdded = new bool[]{false, false, false};
    void Start()
    {
        NPCName = "컵";
        infoA="액체를 담아 마실 수 있는 컵이다.";
        hasOptions = false;

        options = new List<string>{};
        actionText = new List<string>{};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.contains("사과즙") && !itemsAdded[0]){
            options.Add("사과즙을 마신다.");
            actionText.Add("");

            itemsAdded[0] = true;
        }
        if (Inventory.contains("독극물") && !itemsAdded[1]){
            options.Add("독극물을 마신다.");

            actionText.Add("몸이 작아졌다.");

            itemsAdded[1] = true;
        }
        if (Inventory.contains("스테로이드") && !itemsAdded[2]){
            options.Add("스테로이드를 마신다.");

            actionText.Add("힘이 나는 기분이다.");

            itemsAdded[2] = true;
        }
    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if (optionNo == options.IndexOf("사과즙을 마신다.")){ // is applejuice
            Player.TriggerEnding(15);
            return null;
        } else if (optionNo == options.IndexOf("독극물을 마신다.")){ // is poison
            Player.actionConditions[6] = true;

            //change sprite to tiny princess
            PlayerObject.GetComponent<SpriteRenderer>().size *= 0.5f;
        } else if(optionNo == options.IndexOf("스테로이드를 마신다.")){ // is steroid
        
        }
        return actionText[optionNo];
    }
}
