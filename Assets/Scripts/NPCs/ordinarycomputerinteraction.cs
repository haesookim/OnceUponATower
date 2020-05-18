using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordinarycomputerinteraction : NPCInteraction
{
  public GameObject PlayerObject;
  private PlayerInteraction Player;
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "평범한 컴퓨터";
        infoA = "평범한 컴퓨터다.";

        hasOptions = true;
        options = new List<string>{"구동한다."};

        actionText = new List<string>{"드론에 관한 논문을 읽었다. 금새 드론 척척박사가 되었다."};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }


    public override string selectOption(int optionNo){
        if (optionNo == 0){
          Player.actionConditions[1] = true;

        }
        return null;
    }

}
