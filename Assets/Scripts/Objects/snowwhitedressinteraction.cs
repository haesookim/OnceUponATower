using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowwhitedressinteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
      itemName = "백설공주의 옷";
      infoA = "쿨톤에 어울리는 드레스다.";
      infoB = "챙긴다.";
      hasOptions = false;

    }

    // Update is called once per frame
    void Update()
    {
        changeSprite();
    }
}
