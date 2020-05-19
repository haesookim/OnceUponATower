using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrbaekinteraction : NPCInteraction
{

  private bool truffleOil = false;
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "백종원";
        infoA = "백주부가 재료를 손질 중이다.";

        hasOptions = true;
        options = new List<string>{"말을 건다."};

        Inventory = PlayerObject.GetComponent<PlayerInventory>();

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Inventory.contains("트러플 오일") && !truffleOil){
        addOption("트러플 오일을 건넨다", "");
      }
    }

    public override string selectOption(int optionNo){
      Player.optionsBox.SetActive(false);
      if (optionNo == 0){
        Player.TriggerEnding(3);
      }
      else if (optionNo ==1){
        Player.TriggerEnding(13);
        //animation
      }
      return null;
    }
}
