using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doginteraction : NPCInteraction
{
  public Sprite mushroomSprite;
  private bool[] optionsAdded = new bool[]{false};
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "멍멍이";
        infoA = "귀여운 멍멍이다. 쓰다듬고 싶다.";

        hasOptions = true;
        options = new List<string>{"쓰다듬는다."};
        actionText = new List<string>{"멍멍"};

        Inventory = PlayerObject.GetComponent<PlayerInventory>();
        Player = PlayerObject.GetComponent<PlayerInteraction>();

    }


    // Update is called once per frame
    void Update()
    {
      changeSprite();
      if (Inventory.contains("사료")){
        if(!optionsAdded[0]){
          addOption("사료를 먹인다","멍멍이가 송로버섯을 찾았다.");
          optionsAdded[0] = true;
        }
      }
    }

    public override string selectOption(int optionNo){
      Player.optionsBox.SetActive(false);
      if(optionNo ==0){
        return actionText[optionNo];
      }
      if(optionNo ==1){
        Inventory.removeItem("사료");
        Inventory.replaceItem("송로버섯","멍멍이가 송로버섯을 찾았다",mushroomSprite);
        return actionText[optionNo];
      }
      return null;
    }




}
