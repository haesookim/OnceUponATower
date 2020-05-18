using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickInteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "막대기";
        infoA = "단단한 막대기다.";
        infoB="챙긴다";

        hasOptions = true;
        options = new string[]{"부순다"};   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
