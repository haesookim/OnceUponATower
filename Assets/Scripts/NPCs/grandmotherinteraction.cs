using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandmotherinteraction : NPCInteraction
{
  //사과가 0 사료가 1
    private bool[] itemsAdded = new bool[]{false, false};

    void Start()
    {
      NPCName = "욕쟁이 할머니";
      infoA = "인상이 푸근한 할머니다.";

      hasOptions = false;
      options = new List<string>{};

      Inventory = PlayerObject.GetComponent<PlayerInventory>();
      Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    void Update(){
        changeSprite();

        if (Inventory.contains("사과") && !itemsAdded[0]){
          hasOptions = true;
          addOption("사과를 건넨다.", "홀홀홀...이건 먹으면 안돼... 예전에 어느 야윈 처자가 이걸 먹었다가 죽었지...");
          itemsAdded[0] = true;
        }

        if(Inventory.contains("사료") && !itemsAdded[1]){
          hasOptions = true;
          addOption("사료를 건넨다.", "");
          itemsAdded[1] = true;
      }

    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);

        if (optionNo == options.IndexOf("사과를 건넨다.")){
          return actionText[optionNo];
        }

        if (optionNo == options.IndexOf("사료를 건넨다.")){
          Player.TriggerEnding(4);
        }
        return null;
    }



}
