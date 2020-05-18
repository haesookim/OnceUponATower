using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowInteraction : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        NPCName = "창문";
        infoA="하늘이 화사하다.";

        hasOptions = true;
        options = new List<string>{"밖을 내다본다"};
        actionText = new List<string>{};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
