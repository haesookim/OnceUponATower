using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorinteraction : NPCInteraction
{
    private bool[] optionsAdded = new bool[]{false, false};
    // Start is called before the first frame update
    void Start()
    {
      NPCName = "거울";
      infoA = "먼지 낀 작은 거울이다.";

      hasOptions = true;

      options = new List<string>{"살펴본다."};
      actionText = new List<string>{"아름다운 나의 모습이 비친다."};


      Player = PlayerObject.GetComponent<PlayerInteraction>();
      Inventory = PlayerObject.GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
      changeSprite();
      if(Inventory.contains("백설공주의 옷")){
        addOption("백설공주의 옷을 입는다.","백설공주로 변신했다!");
        optionsAdded[0]=true;
      }

    }

    public override string selectOption(int optionNo){
      Player.optionsBox.SetActive(false);
      if(optionNo==0){
        return actionText[optionNo];
      }
      else if (optionNo==1){

        if(Inventory.contains("사과")){
          Player.actionConditions[3]=true;
          return actionText[optionNo];
        }
        else{
          Player.TriggerEnding(11);
          return null;
        }
      }
      return null;
    }





}
