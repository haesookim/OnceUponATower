using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallinteraction : NPCInteraction
{
  public bool itemAdded = false;
    // Start is called before the first frame update
    void Start()
    {
      NPCName = "벽";
      infoA = "자세히 보니 부서질 것 같다.";

      hasOptions = false;
      options = new List<string>{};


      Player = PlayerObject.GetComponent<PlayerInteraction>();



    }
    void Update(){

      if (Player.actionConditions[7] && !itemAdded){
        addOption("부순다!", "");
        itemAdded = true;
        hasOptions = true;
      }
    }

    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if (optionNo == 0){
          Player.TriggerEnding(19);
        }
        return null;
    }


}
