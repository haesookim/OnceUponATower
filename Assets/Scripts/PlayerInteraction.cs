using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{   
    // Canvas Text interaction
    public Canvas dialogue;
    public Text informationText;
    public Text[] options = new Text[2]; // TODO: This needs to change variably
    public Image highlight;

    private bool dialogueActive;
    private bool NPCActive;

    private InteractableObject currentObj;
    private int optionNumber = 0;


    // for moving across Rooms
    private bool doorActive;

    private Door currentDoor;

    //for inventory
    public PlayerInventory inventory;

    void Start(){
        dialogue = GameObject.Find("DialogueCanvas").GetComponent<Canvas>();
        inventory = gameObject.GetComponent<PlayerInventory>();
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

    private void OnTriggerExit2D(Collider2D col){
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

            informationText.text = currentObj.interactionText;
            if (currentObj.hasOptions){
                for (int i = 0; i<currentObj.options.Length; i++){
                    options[i].text = currentObj.options[i];
                }
            } else{
                //Hide?
            }

            // Key bindings for dialogue UI
            if (Input.GetKeyDown(KeyCode.UpArrow)){
				optionNumber = (optionNumber + 1) % 2; // TODO: Fix according to count of options
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)){
				optionNumber = (optionNumber + 1) % 2; // TODO: Fix according to count of options
			}
            highlight.transform.position = options[optionNumber].transform.position;


            if (Input.GetKeyDown(KeyCode.Return))
			{
				//select option
                if (currentObj.endingTriggers[optionNumber] != 0){
                    TriggerEnding(currentObj.endingTriggers[optionNumber]);
                } else if (currentObj.inventoryTriggers[optionNumber]){
                    inventory.addItem(currentObj);
                    Destroy(currentObj.gameObject);
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
				this.transform.position = currentDoor.getDestination(); // This should be the coordinates for the moved location
			}
        }
    }
}
