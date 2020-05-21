using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinkerbellInteraction : InteractableObject
{
    void Start()
    {
        itemName = "팅커벨";
        infoA="에버랜드 출신의 팅커벨이다.";
        infoB="데리고 간다.";
        hasOptions = false;
        
    }

    void Update(){
        changeSprite();
    }
}
