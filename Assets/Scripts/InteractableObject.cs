using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // for inventory
    public string itemName;
    //public sprite itemSprite;
    
    // for initializing interactions
    public string interactionText;

    public bool hasOptions;
    public string[] options;
    public int[] endingTriggers;
    public bool[] inventoryTriggers;

}