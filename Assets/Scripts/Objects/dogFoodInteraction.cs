﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogFoodInteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "사료";
        infoA = "멍멍이가 먹을 거 같은 사료다.";
        infoB = "챙긴다";

        hasOptions = true;
        options = new string[]{"먹는다"};
        actionText = new string[]{"placeholder"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}