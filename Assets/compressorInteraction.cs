using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compressorInteraction : MonoBehaviour
{
    public GameObject Player;
    public PlayerInventory inventory;
    public PlayerInteraction interaction;

    public InteractableObject compressor;

    void Start(){
        inventory = Player.GetComponent<PlayerInventory>();
        interaction = Player.GetComponent<PlayerInteraction>();

        compressor = gameObject.GetComponent<InteractableObject>();
    }

    void Update(){
        if (inventory.contains("apple")){
            compressor.hasOptions = true;
            compressor.options[0] = "사과를 집어넣는다";
            compressor.inventoryTriggers[0] = true;
        }
    }
}
