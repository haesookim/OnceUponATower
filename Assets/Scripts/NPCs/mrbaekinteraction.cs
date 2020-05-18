using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrbaekinteraction : NPCInteraction
{
  public GameObject PlayerObject;
  private PlayerInteraction Player;
  private PlayerInventory PlayerInv;
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "백종원";
        infoA = "백주부가 재료를 손질 중이다.";

        hasOptions = true;
        options = new string[]{"말을 건다."};



        PlayerInv = PlayerObject.GetComponent<PlayerInventory>();

        Player = PlayerObject.GetComponent<PlayerInteraction>();


    }



    // Update is called once per frame
    void Update()
    {
      if (PlayerInv.inventory.ContainsKey("트러플 오일")){
        options.append{"트러플 오일을 건낸다."};
        Player.TriggerEnding(3);
        //animation
      }



    }


}
