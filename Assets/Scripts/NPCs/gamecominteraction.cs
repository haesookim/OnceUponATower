using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecominteraction : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {

        NPCName = "게이밍 컴퓨터";
        infoA = "고사양 게이밍 컴퓨터다.";

        hasOptions = true;
        options = new List<string>{"구동한다."};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if (optionNo == 0){
          Player.TriggerEnding(2);
        }
        return null;
    }
}
