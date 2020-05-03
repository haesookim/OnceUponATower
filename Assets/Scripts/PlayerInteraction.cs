using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Canvas dialogue;
    private bool dialogueActive;
    private int optionNumber = 0;

    void Start(){
        dialogue = GameObject.Find("Dialogue Canvas").GetComponent<Canvas>();
    }

    // Enter and Exit Interactable Objects
    // Must be tagged as "interactableObject"
    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "interactableObject"){
            optionNumber = 0;
            dialogueActive = true;            
        }
    }

    private void onTriggerExit2D(Collider2D col){
        if (col.tag == "interactableObject"){
            dialogueActive = false;
        }
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
			}
        } else{
            dialogue.gameObject.SetActive(false);
        }
    }
}
