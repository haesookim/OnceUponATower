using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // for inventory
    public string itemName;

    //public sprite itemSprite;
    
    // for initializing interactions
    public string infoA;
    public string infoB;

    // list of provided options
    public string[] options;

    // list of action text responses in accordance to options
    public string[] actionText;

    public virtual string selectOption(int optionNo){
        return actionText[optionNo];
    }
}