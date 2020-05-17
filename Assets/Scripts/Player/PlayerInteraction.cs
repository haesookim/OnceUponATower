using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{   
    // Canvas Text interaction
    public Canvas dialogueCanvas;
    public GameObject optionItem;

    private bool dialogueActive;
    private bool NPCActive;

    private InteractableObject currentObj;
    private NPCInteraction currentNPC;

    // for moving across Rooms
    public Canvas doorCanvas;

    private bool doorActive;

    private Door currentDoor;

    //for inventory
    [SerializeField] private PlayerInventory inventory;

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

            GameObject.Find("ObjName").GetComponent<Text>().text = currentObj.itemName;
            GameObject.Find("infoA").GetComponent<Text>().text = currentObj.infoA;
            GameObject.Find("infoB").GetComponent<Text>().text = currentObj.infoB;

            if (currentObj.hasOptions){
                GameObject parent = GameObject.Find("OptionsParent");
                parent.SetActive(true);
                for (int i = 1; i < currentObj.optionCount; i++){
                    GameObject newOption = Instantiate(optionItem);
                    optionItem.transform.SetParent(parent.transform);
                }
            }
        } else if (col.tag == "NPC"){
            dialogueActive = true;
            dialogueCanvas.gameObject.SetActive(true);

            currentNPC = col.gameObject.GetComponent<NPCInteraction>();
        } else if(col.tag == "dragon"){
            TriggerEnding(6);
        }

        if (col.tag == "door"){
            doorActive = true;
            doorCanvas.gameObject.SetActive(true);
            currentDoor = col.gameObject.GetComponent<Door>();

            GameObject.Find("DoorName").GetComponent<Text>().text = currentDoor.positionName;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.tag == "interactableObject"){
            dialogueActive = false;
            dialogueCanvas.gameObject.SetActive(false);

            if (currentObj.hasOptions){
                GameObject parent = GameObject.Find("OptionsParent");
                parent.SetActive(false);
                for (int i = 1; i < currentObj.optionCount; i++){
                    Destroy(parent.transform.GetChild(i));
                }
            }

        } else if (col.tag == "NPC"){
            dialogueActive = false;
            dialogueCanvas.gameObject.SetActive(false);
        }

        if (col.tag == "door"){
            doorActive = false;
            doorCanvas.gameObject.SetActive(false);
        }
    }

    public void TriggerEnding(int endingNo){
        //endingText.text="Ending number "+ endingNo+ " triggered\n";
        // move to scene No. of ending
        Debug.Log("Ending number "+ endingNo+ " triggered");
    }

    void Update(){
        if (dialogueActive){
            //informationText.text = currentObj.infoA;
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
                inventory.addItem(currentObj);
                Destroy(currentObj.gameObject);
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
