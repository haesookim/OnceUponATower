using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandmotherinteraction : NPCInteraction
{
  public GameObject PlayerObject;
  private PlayerInteraction Player;

    void Start()
    {
      NPCName = "욕쟁이 할머니";
      infoA = "인상이 푸근한 할머니다.";

      hasOptions = true;
      options = new List<string>{"말을 건다."};

      Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    public override string selectOption(int optionNo){
        if (optionNo == 0){
          Player.TriggerEnding(4);
        }
        return null;
    }


}
