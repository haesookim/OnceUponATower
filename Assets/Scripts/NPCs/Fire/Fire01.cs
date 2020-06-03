using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire01 : NPCInteraction
{
    // Start is called before the first frame update
    void Start()
    {
      NPCName = "횃불 00";
      infoA = "꺼진 횃불이다.";

      hasOptions = true;
      options = new List<string>{"구동한다."};

      Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
