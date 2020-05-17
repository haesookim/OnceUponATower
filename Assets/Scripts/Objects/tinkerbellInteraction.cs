using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinkerbellInteraction : InteractableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "팅커벨";
        infoA="placeholder";
        infoB="데리고 간다";
        hasOptions = true;
        options = new string[]{"test", "test2", "test3", "test4"};
        actionText = new string[]{"1번을 선택했다", "2번을 선택했다"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
