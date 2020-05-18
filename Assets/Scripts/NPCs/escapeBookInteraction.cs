using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeBookInteraction : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        NPCName="탈출의 상식";
        infoA = "탈출의 상식이 가득 적혀있는 책이다.";

        hasOptions = true;
        options = new List<string>{"읽는다."};
    }

    public override string selectOption(int optionNo){
        if (optionNo == 0){
            //show morse code image;
        }
        return null;
    }
}
