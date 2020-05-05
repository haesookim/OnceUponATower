using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonInteraction : MonoBehaviour
{
    public GameObject Player;
    public PlayerInventory inventory;
    public PlayerInteraction interaction;

    private bool isAwake = true;

    void Start(){
        inventory = Player.GetComponent<PlayerInventory>();
        interaction = Player.GetComponent<PlayerInteraction>();
    }

    void Update(){
        if (isAwake){
            //GameObject.
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player" && isAwake){
            if (inventory.contains("apple")){
                if (inventory.contains("drone")){

                } else if (inventory.contains("tinkerbell")){

                } else {

                }
            }
            interaction.TriggerEnding(6);
        }
    }
}
