using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int inventorySize = 13;
    public InteractableObject[] inventory;
    public int currentInventoryCount;

    public bool inventoryActive;

    void Start(){
        inventory = new InteractableObject[inventorySize];
        currentInventoryCount = 0;
    }

    public void addItem(InteractableObject item){
        if (currentInventoryCount < inventorySize){
            inventory[currentInventoryCount] = item;
            currentInventoryCount ++;
        } else {
            Debug.Log("Inventory Full!");
        }
    }

    // check for item
    public bool contains(string itemName){
        for (int i = 0; i<currentInventoryCount; i++){
            if (inventory[currentInventoryCount].itemName == itemName){
                return true;
            }
        }
        return false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.I)){
            inventoryActive = !inventoryActive; // Toggle inventory status
        }
    }
}
