using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Sprite activeImage;
    public Sprite baseImage;
    public bool active;
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

    void Start(){
        baseImage = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void changeSprite(){
        if (active){
            gameObject.GetComponent<SpriteRenderer>().sprite = activeImage;
        } else{
            gameObject.GetComponent<SpriteRenderer>().sprite = baseImage;
        }
    }

    public virtual string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        return actionText[optionNo];
    }

    public void addOption(string newOption, string newActionText){
        options.Add(newOption);
        actionText.Add(newActionText);
    }
}