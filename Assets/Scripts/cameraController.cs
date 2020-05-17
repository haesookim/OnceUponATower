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
    void Update()
    {   
        Vector3 newPos = this.transform.position;
        newPos.y = player.transform.position.y + 1.6f;
        float positionOffset = this.transform.position.x - player.transform.position.x;

        if (positionOffset>offset){
            newPos.x = player.transform.position.x +offset;
        } else if (positionOffset < -offset) {
            newPos.x = player.transform.position.x -offset;
        }

        this.transform.position = newPos;
    }
}
