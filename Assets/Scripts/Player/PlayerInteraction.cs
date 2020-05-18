using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{   
    // Canvas Text interaction
    public Canvas dialogueCanvas;
    public GameObject optionItem;
    public GameObject optionsParent;

    private bool dialogueActive;
    private bool NPCActive;

    private InteractableObject currentObj;
    private NPCInteraction currentNPC;

    // for moving across Rooms
    public Canvas doorCanvas;
    public GameObject doorParent;
    private bool doorActive;
    public bool teleported = false;

    private Door currentDoor;

    //for inventory
    [SerializeField] private PlayerInventory inventory;

    public Canvas inventoryCanvas;
    private int selectedOption = 0;
    private int selectedDoor = 0;

    //conditions checker;
    public Dictionary<int, bool> actionConditions = new Dictionary<int, bool>{
        {1, false}, 
        {2, false},
        {3, false},
        {6, false}
        };

    void Start(){
        dialogueCanvas = GameObject.Find("interactionCanvas").GetComponent<Canvas>();
        inventoryCanvas = GameObject.Find("inventoryCanvas").GetComponent<Canvas>();
        doorCanvas = GameObject.Find("DoorCanvas").GetComponent<Canvas>();
        
        
        inventory = gameObject.GetComponent<PlayerInventory>();

    }

    // Enter and Exit Interactable Objects
    // Must be tagged as "interactableObject" or "NPC"
    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "interactableObject" || col.tag == "NPC"){
            selectedOption = 0;
            dialogueActive = true;
            dialogueCanvas.gameObject.SetActive(true);

            if (col.tag == "interactableObject"){
                currentObj = col.gameObject.GetComponent<InteractableObject>(); 
                GameObject.Find("ObjName").GetComponent<Text>().text = currentObj.itemName;
                GameObject.Find("infoA").GetComponent<Text>().text = currentObj.infoA;
                GameObject.Find("infoB").GetComponent<Text>().text = currentObj.infoB;

                if (currentObj.hasOptions){
                    for (int i = 0; i <currentObj.options.Length; i++){
                        GameObject newOption = Instantiate(optionItem, optionsParent.transform);
                        newOption.transform.GetChild(0).GetComponent<Text>().text = currentObj.options[i];
                        newOption.transform.SetParent(optionsParent.transform, false);
                    }
                }
            } else if (col.tag =="NPC"){
                currentNPC = col.gameObject.GetComponent<NPCInteraction>();
                GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
                GameObject.Find("infoA").GetComponent<Text>().text = currentNPC.infoA;

                if (currentNPC.hasOptions){
                    for (int i = 0; i <currentNPC.options.Length; i++){
                        GameObject newOption = Instantiate(optionItem, optionsParent.transform);
                        newOption.transform.GetChild(0).GetComponent<Text>().text = currentNPC.options[i];
                        newOption.transform.SetParent(optionsParent.transform, false);
                    }
                }
            }

        } else if(col.tag == "dragon"){
            TriggerEnding(6);
        }

        if (col.tag == "door"){
            selectedDoor = 0;
            doorActive = true;
            doorCanvas.gameObject.SetActive(true);
            currentDoor = col.gameObject.GetComponent<Door>();

            GameObject.Find("DoorName").GetComponent<Text>().text = currentDoor.positionName;
            
            for (int i = 0; i < currentDoor.goalPosition.Length ; i++){
                GameObject newOption = Instantiate(optionItem, doorParent.transform);
                newOption.transform.GetChild(0).GetComponent<Text>().text = currentDoor.goalPosition[i].positionName;
                newOption.transform.SetParent(doorParent.transform, false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.tag == "interactableObject" || col.tag == "NPC"){
            dialogueActive = false;
            dialogueCanvas.gameObject.SetActive(false);

            if (col.tag=="interactableObject" && currentObj.hasOptions ||col.tag == "NPC" && currentNPC.hasOptions){
                for (int i = 0; i < optionsParent.transform.childCount; i++){
                    Destroy(optionsParent.transform.GetChild(i).gameObject);
                }
            }
        }

        if (col.tag == "door"){
            doorActive = false;
            doorCanvas.gameObject.SetActive(false);
            for (int i = 0; i < doorParent.transform.childCount; i++){
                Destroy(doorParent.transform.GetChild(i).gameObject);
            }
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
            if (currentObj.hasOptions){
                if (Input.GetKeyDown(KeyCode.UpArrow)){
                    selectedOption = (selectedOption + coefficient - 1)%coefficient;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)){
                    selectedOption = (selectedOption + 1)%coefficient;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
			{
                GameObject.Find("infoA").GetComponent<Text>().text = currentObj.selectOption(selectedOption); // code in individual Objects
                GameObject.Find("infoB").GetComponent<Text>().text = "";
                optionsParent.SetActive(false);
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
                teleported = true;
				this.transform.position = currentDoor.getDestination(currentDoor.goalPosition[selectedDoor]); // This should be the coordinates for the moved location
			}
        }
    }
}
