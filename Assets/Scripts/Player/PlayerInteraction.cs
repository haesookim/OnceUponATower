using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{   
    // Canvas Text interaction
    public Canvas dialogueCanvas;
    public Text informationText;
    public Image highlight;

    private bool dialogueActive;
    private bool NPCActive;

    private InteractableObject currentObj;
    private NPCInteraction currentNPC;

    // for moving across Rooms
    public Canvas doorCanvas;

    private bool doorActive;

    private Door currentDoor;

    //for inventory
    public PlayerInventory inventory;

    public Canvas inventoryCanvas;
    private int selectedOption = 0;
    private int selectedDoor = 0;

    void Start(){
        dialogueCanvas = GameObject.Find("interactionCanvas").GetComponent<Canvas>();
        inventoryCanvas = GameObject.Find("inventoryCanvas").GetComponent<Canvas>();
        doorCanvas = GameObject.Find("DoorCanvas").GetComponent<Canvas>();
        inventory = gameObject.GetComponent<PlayerInventory>();
    }

    // Enter and Exit Interactable Objects
    // Must be tagged as "interactableObject" or "NPC"
    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "interactableObject"){
            selectedOption = 0;
            dialogueActive = true;
            dialogueCanvas.gameObject.SetActive(true);

            currentObj = col.gameObject.GetComponent<InteractableObject>();
        } else if (col.tag == "NPC"){
            dialogueActive = true;
            dialogueCanvas.gameObject.SetActive(true);

            currentNPC = col.gameObject.GetComponent<NPCInteraction>();
        } else if(col.tag == "dragon"){
            TriggerEnding(6);
        }

        if (col.tag == "door"){
            doorActive = true;
            currentDoor = col.gameObject.GetComponent<Door>();
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.tag == "interactableObject"){
            dialogueActive = false;
            dialogueCanvas.gameObject.SetActive(false);

        } else if (col.tag == "NPC"){
            dialogueActive = false;
            dialogueCanvas.gameObject.SetActive(false);
        }

        if (col.tag == "door"){
            doorActive = false;
        }
    }

    public void TriggerEnding(int endingNo){
        //endingText.text="Ending number "+ endingNo+ " triggered\n";
        // move to scene No. of ending
        Debug.Log("Ending number "+ endingNo+ " triggered");
    }

    void Update(){
        if (dialogueActive){
            informationText.text = currentObj.infoA;
            int coefficient = currentObj.options.Length;
            
            // Key bindings for dialogue UI
            if (coefficient > 0){
                if (Input.GetKeyDown(KeyCode.UpArrow)){
                    selectedOption = (selectedOption + coefficient - 1)%coefficient;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)){
                    selectedOption = (selectedOption + 1)%coefficient;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
			{
				currentObj.selectOption(selectedOption); // code in individual Objects
			}

            if (Input.GetKeyDown(KeyCode.Q)){
                // put item into Inventory
                inventory.addItem(currentObj);
            }
        }

        if (NPCActive){
            if (Input.GetKeyDown(KeyCode.Return))
			{
				dialogueActive = true;
			}
        }

        if (doorActive){
            int coefficient = currentDoor.goalPosition.Length;

            if (Input.GetKeyDown(KeyCode.UpArrow)){
                selectedDoor = (selectedDoor + coefficient - 1)%coefficient;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)){
                selectedDoor = (selectedDoor + 1)%coefficient;
            }

            if (Input.GetKeyDown(KeyCode.Return))
			{
				this.transform.position = currentDoor.getDestination(currentDoor.goalPosition[selectedDoor]); // This should be the coordinates for the moved location
			}
        }
    }
}
