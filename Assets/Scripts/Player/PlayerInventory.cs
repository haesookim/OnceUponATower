using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
    private int inventorySize = 13;
    public GameObject InventoryParent;
    private Dictionary<string, string> inventory = new Dictionary<string, string>();
    public Sprite[] inventoryImage;
    public Image[] inventoryUIImage;
    public int currentInventoryCount;

    //public bool inventoryActive;

    void Start(){
        inventoryImage = new Sprite[inventorySize];
        inventoryUIImage = new Image[inventorySize];
        currentInventoryCount = 0;

        for (int i = 0; i <inventorySize; i++){
            inventoryUIImage[i] = InventoryParent.transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void addItem(InteractableObject item){
        if (currentInventoryCount < inventorySize){
            inventory.Add(item.itemName, item.infoA);
            inventoryImage[currentInventoryCount] = item.itemSprite;
            inventoryUIImage[currentInventoryCount].sprite = item.itemSprite;
        } else {
            Debug.Log("Inventory Full!");
        }
    }
    // check for item
    public bool contains(string itemName){
        if (inventory.ContainsKey(itemName)){
            return true;
        }
        return false;
    }
}
