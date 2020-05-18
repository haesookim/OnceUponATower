using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowInteraction : NPCInteraction
{
    public GameObject PlayerObject;
    public PlayerInteraction Player;
    public PlayerInventory Inventory;
    private bool[] optionsAdded = new bool[]{false, false};
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "창문";
        infoA="하늘이 화사하다.";

        hasOptions = true;
        options = new List<string>{"밖을 내다본다"};
        actionText = new List<string>{"창문 바깥으로 용이 보인다."};

        Inventory = PlayerObject.GetComponent<PlayerInventory>();
        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.contains("사과즙") && Inventory.contains("드론")){
            if(!optionsAdded[0]){
                addOption("드론으로 사과즙을 뿌린다", "드론을 어떻게 날리는지 모르겠다");
                optionsAdded[0] = true;
            }
            // if (Player.actionConditions(1)){
            //     actionText[options.IndexOf("드론으로 사과즙을 뿌린다")]
            // }
        }

        if (Inventory.contains("사과즙") && Inventory.contains("팅커벨")){
            if(!optionsAdded[1]){
                addOption("팅커벨에게 사과즙을 뿌려달라고 부탁한다.", "");
            }
        } 
    }

    public override string selectOption(int optionNo){
        if( optionNo == 0){
            return actionText[optionNo];
        }
        else if (optionNo == options.IndexOf("드론으로 사과즙을 뿌린다")){
            if (Player.actionConditions[1]){
                Player.TriggerEnding(5);
                return null;
            } else{
                return actionText[optionNo];
            }
        } else if (optionNo == options.IndexOf("팅커벨에게 사과즙을 뿌려달라고 부탁한다.")){
            Player.TriggerEnding(7);
            return null;
        }
        return null;
    }
}
