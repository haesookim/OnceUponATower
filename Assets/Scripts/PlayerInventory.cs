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
}
