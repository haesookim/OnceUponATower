using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector3 newPos = this.transform.position;
        float positionOffset = this.transform.position.x - player.transform.position.x;

        if (positionOffset>offset){
            newPos.x = player.transform.position.x+offset;
        } else if (positionOffset < -offset) {
            newPos.x = player.transform.position.x-offset;
        }

        if (player.GetComponent<PlayerInteraction>().teleported){
            //newPos.x = player.transform.position.x;
            newPos.y = player.transform.position.y + 1.6f;
            player.GetComponent<PlayerInteraction>().teleported = false;
        }
        this.transform.position = newPos;
    }
}
