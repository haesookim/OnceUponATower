using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Vector3 position;
    public Door[] goalPosition;

    public string[] locationText;

    //use for future location reference
    public string positionName;

    void Start(){
        position = gameObject.GetComponent<Transform>().position;

        // assign current 
        for (int i = 0; i<goalPosition.Length; i++){
            locationText[i] = goalPosition[i].positionName;
        }
    }

    public Vector3 getDestination(Door selectedDoor){
        return selectedDoor.position;
    }
}
