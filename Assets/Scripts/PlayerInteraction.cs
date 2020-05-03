using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Canvas dialogue;
    private bool dialogueActive;
    private bool NPCActive;

    private InteractableObject currentObj;
    private int optionNumber = 0;


    // for moving across Rooms
    private bool doorActive;

    private Door currentDoor;

    void Start(){
        dialogue = GameObject.Find("DialogueCanvas").GetComponent<Canvas>();
    }

    // Enter and Exit Interactable Objects
    // Must be tagged as "interactableObject" or "NPC"
    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "interactableObject"){
            optionNumber = 0;
            dialogueActive = true;

            currentObj = col.gameObject.GetComponent<InteractableObject>();
        } else if (col.tag == "NPC"){
            NPCActive = true;
            currentObj = col.gameObject.GetComponent<InteractableObject>();
        }

        if (col.tag == "door"){
            doorActive = true;
            currentDoor = col.gameObject.GetComponent<Door>();
        }
    }

    private void onTriggerExit2D(Collider2D col){
        if (col.tag == "interactableObject"){
            dialogueActive = false;
        } else if (col.tag == "NPC"){
            NPCActive = false;
            dialogueActive = false;
        }

        if (col.tag == "door"){
            doorActive = false;
        }
    }

    private void TriggerEnding(int endingNo){
        // move to scene No. of ending
        Debug.Log("Ending number "+ endingNo+ " triggered");
    }

    void Update(){
        if (dialogueActive){
            dialogue.gameObject.SetActive(true);

            // Key bindings for dialogue UI
            if (Input.GetKeyDown(KeyCode.UpArrow)){
				optionNumber = (optionNumber + 2) % 2; // TODO: Fix according to count of options
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)){
				optionNumber = (optionNumber + 1) % 2; // TODO: Fix according to count of options
			}
            if (Input.GetKeyDown(KeyCode.Return))
			{
				//select option
                if (currentObj.endingTriggers[optionNumber] != 0){
                    // trigger Ending
                } else if (currentObj.inventoryTriggers[optionNumber]){
                    // add to Inventory
                }
			}
        } else{
            dialogue.gameObject.SetActive(false);
        }

        if (NPCActive){
            if (Input.GetKeyDown(KeyCode.Return))
			{
				dialogueActive = true;
			}
        }

        if (doorActive){
            if (Input.GetKeyDown(KeyCode.Return))
			{
				Debug.Log(currentDoor.getDestination()); // This should be the coordinates for the moved location
			}
        }
    }
}
