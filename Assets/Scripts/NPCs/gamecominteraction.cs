using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecominteraction : NPCInteraction
{
  public GameObject PlayerObject;
  private PlayerInteraction Player;
    // Start is called before the first frame update
    void Start()
    {

        NPCName = "게이밍 컴퓨터";
        infoA = "고사양 게이밍 컴퓨터.";

        hasOptions = true;
        options = new string[]{"구동한다."};


    }

    public override string selectOption(int optionNo){
        if (optionNo == 0){
          Player.TriggerEnding(2);
        }
        return null;
    }
}
