using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchesInteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "성냥";
        infoA = "방수 잘 되는 성냥이다.";
        infoB = "챙긴다.";

        hasOptions = false;
    }

    // Update is called once per frame
    void Update(){
        changeSprite();
    }
}
