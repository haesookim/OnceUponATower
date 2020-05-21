using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinkerbellInteraction : InteractableObject
{
    void Start()
    {
        itemName = "팅커벨";
        infoA="placeholder";
        infoB="데리고 간다";
        hasOptions = false;
        
    }

    void Update(){
        changeSprite();
    }
}
