﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public string infoA;

    // list of provided options
    public string[] options;

    // list of action text responses in accordance to options
    public string[] actionText;

    public virtual string selectOption(int optionNo){
        return actionText[optionNo];
    }
}