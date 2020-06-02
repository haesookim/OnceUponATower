using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smalldoorinteraction : NPCInteraction
{
    private bool isTinkerbell = false;
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "작은 문";
        infoA = "작은 문이다.";

        hasOptions = true;
        options = new List<string>{"들어간다."};
        actionText = new List<string>{"너무 작아 들어갈 수 없다."};

        Inventory = PlayerObject.GetComponent<PlayerInventory>();
        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    public override string selectOption(int optionNo){
      Player.optionsBox.SetActive(false);
        if (optionNo == 0){
          if(Player.actionConditions[6]){
            //animation 엄지공주가 문으로 들어가는
            Player.TriggerEnding(17);
          }
          else{
            return actionText[optionNo];
          }
        }
        else if(optionNo == options.IndexOf("팅커벨을 내보낸다.")){
          Inventory.removeItem("팅커벨");
          options.Remove("팅커벨을 내보낸다.");
          return actionText[optionNo];

        }
        return null;
    }
    void Update(){
        changeSprite();

        if(Inventory.contains("팅커벨") && !isTinkerbell){
          addOption("팅커벨을 내보낸다.", "팅커벨이 사라졌다. 곧 에버랜드 개장 시간이라고 한다.");
          isTinkerbell = true;
      }


    }


}
