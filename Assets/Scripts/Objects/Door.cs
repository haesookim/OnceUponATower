using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Vector3 position;
    public Door goalPosition;

    public Text locationText;

    //use for future location reference
    public string positionName;

    void Start(){
        locationText = GameObject.Find("LocationText").GetComponent<Text>();
        position = gameObject.GetComponent<Transform>().position;
    }

    public Vector3 getDestination(){
        locationText.text = this.positionName;
        return goalPosition.position;
    }
}
