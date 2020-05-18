using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public string NPCName;
    public string infoA;

    public bool hasOptions;
    // list of provided options
    public List<string> options;

    public GameObject PlayerObject;
    public PlayerInteraction Player;
    public PlayerInventory Inventory;

    // list of action text responses in accordance to options
    public List<string> actionText;

    public virtual string selectOption(int optionNo){
        return actionText[optionNo];
    }

    public void addOption(string newOption, string newActionText){
        options.Add(newOption);
        actionText.Add(newActionText);
    }
}