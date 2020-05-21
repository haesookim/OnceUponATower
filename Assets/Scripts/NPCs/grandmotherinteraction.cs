﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandmotherinteraction : NPCInteraction
{

    void Start()
    {
      NPCName = "욕쟁이 할머니";
      infoA = "인상이 푸근한 할머니다.";

      hasOptions = true;
      options = new List<string>{"말을 건다."};

      Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

  void Update(){
        changeSprite();
    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if (optionNo == 0){
          Player.TriggerEnding(4);
        }
        return null;
    }


}
