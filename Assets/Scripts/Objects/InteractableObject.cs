using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    // for inventory
    public GameObject PlayerObject;
    public PlayerInteraction Player;
    
    public string itemName;

    public Sprite itemSprite;
    public Sprite activeSprite;
    public bool active = false;
    
    // for initializing interactions
    public string infoA;
    public string infoB;

    public bool hasOptions = false;

    // list of provided options
    public string[] options = {};

    // list of action text responses in accordance to options
    public string[] actionText = {};

    void Start(){
        //this code is not working right now
        itemSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void changeSprite(){
        if(active){
            gameObject.GetComponent<SpriteRenderer>().sprite = activeSprite;
        } else{
            gameObject.GetComponent<SpriteRenderer>().sprite = itemSprite;
        }
    }

    public virtual string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        return actionText[optionNo];
    }
}