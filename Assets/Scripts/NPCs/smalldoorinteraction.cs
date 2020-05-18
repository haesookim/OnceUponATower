using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smalldoorinteraction : NPCInteraction
{
  public GameObject PlayerObject;
  private PlayerInteraction Player;
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "작은 문";
        infoA = "작은 문이다.";

        hasOptions = true;
        actionText = new List<string>{"너무 작아 들어갈 수 없다."};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    public override string selectOption(int optionNo){
        if (optionNo == 0){
          if(Player.actionConditions[6]){
            //animation 엄지공주가 문으로 들어가는

            Player.TriggerEnding(17);

          }

        }
        return null;
    }


}
