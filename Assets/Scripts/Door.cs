using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 position;
    public Door goalPosition;

    void Start(){
        position = gameObject.GetComponent<Transform>().position;
    }

    public Vector3 getDestination(){
        return goalPosition.position;
    }
}
