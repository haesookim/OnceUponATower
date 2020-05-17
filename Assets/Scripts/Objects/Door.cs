using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    //In-map position where door is located
    public Vector3 position;

    // Room where door is located
    public string positionName;
    public Door[] goalPosition;

    public string[] locationText;


    void Start(){
        position = gameObject.GetComponent<Transform>().position;

        // assign current 
        for (int i = 0; i<goalPosition.Length; i++){
            locationText[i] = goalPosition[i].positionName;
        }
    }

    public Vector3 getDestination(Door selectedDoor){
        Vector3 alteredPosition = selectedDoor.position;
        alteredPosition.y -= 2f;
        return alteredPosition;
    }
}
