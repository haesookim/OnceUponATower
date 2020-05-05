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

    // Temporary ending logic
    public Canvas ending;
    public Text endingText;

    public string[] endinginfo = {"", "독사과였다.", "공주는 승부욕이 강하다. 마스터 티어를 찍으려면 성을 떠날 수 없다.", "백주부가 뿌린 설탕이 코에 들어갔다. 호흡곤란으로 그만…", "앗, 욕쟁이 할머니었다. 공주는 마상을 입고 죽었다.", "앗, 드론 파편이 공주의 미간에 꽂혔다.", "겁도 없이 용에게 달려든 공주는 그대로 통구이가 되었다.", "공주는 어이가 없어서 죽었다.", ""};

    void Start(){
        dialogue = GameObject.Find("DialogueCanvas").GetComponent<Canvas>();
        ending.gameObject.SetActive(false);
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
        } else if (col.tag == "NPC"){
            NPCActive = false;
            dialogueActive = false;
        }

        if (col.tag == "door"){
            doorActive = false;
        }
    }

    public void TriggerEnding(int endingNo){
        ending.gameObject.SetActive(true);
        endingText.text="Ending number "+ endingNo+ " triggered\n"+endinginfo[endingNo];
        // move to scene No. of ending
        Debug.Log("Ending number "+ endingNo+ " triggered");
    }

    void Update(){
        if (dialogueActive){
            dialogue.gameObject.SetActive(true);

            informationText.text = currentObj.interactionText;
            if (currentObj.hasOptions){
                highlight.enabled=true;
                for (int i = 0; i<currentObj.options.Length; i++){
                    options[i].text = currentObj.options[i];
                }
            } else {
                highlight.enabled=false;
                for (int i = 0; i<2; i++){
                    options[i].text = "";
                }
            }

            // Key bindings for dialogue UI
            if (Input.GetKeyDown(KeyCode.UpArrow)){
				optionNumber = (optionNumber + options.Length - 1) % options.Length; // TODO: Fix according to count of options
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)){
				optionNumber = (optionNumber + 1) % options.Length; // TODO: Fix according to count of options
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
