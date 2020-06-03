using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallinteraction : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {
      NPCName = "벽";
      infoA = "부서질 것 같다";

      hasOptions = true;

      options = new List<string>{"부순다!"};


      Player = PlayerObject.GetComponent<PlayerInteraction>();


    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if (optionNo == 0){
          Player.TriggerEnding(19);
        }
        return null;
    }


}
