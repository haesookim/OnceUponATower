using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int inventorySize = 10;
    public InteractableObject[] inventory;
    public int currentInventoryCount;

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

    public bool contains(string itemName){
        return true;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.I)){
            for (int i = 0; i< currentInventoryCount; i++){
                Debug.Log(inventory[i].itemName);
            }
        }
    }
}
