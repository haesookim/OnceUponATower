using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princeinteraction : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        NPCName="왕자";
        infoA = "백마 탄 왕자다.";

        hasOptions = true;
        options = new List<string>{"말을 건다."};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    public override string selectOption(int optionNo){
        if (optionNo == 0){

          if(Player.actionConditions[2]){
            
            Player.TriggerEnding(8);
            return @"『공주님! 무사하셨군요. 아아… 정말 다행입니다.
            용맹한 제가 용을 무찔렀어요. 이제 안심하셔도 됩니다.
            일단 이곳을 빠져나가요. 맥시무스, 공주님을 도와드려.』";

          }
          else{
            Player.TriggerEnding(6);
            return @"『공주님! 무사하셨군요. 아아… 정말 다행입니다.
            용맹한 제가 용을 무찔러 드릴게요. 이제 안심하셔도 됩니다.
            맥시무스, 가자!』";

          }

        }
        return null;
    }




}
