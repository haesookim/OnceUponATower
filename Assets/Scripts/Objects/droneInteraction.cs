using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneInteraction : InteractableObject
{
    public GameObject PlayerObject;
    private PlayerInteraction Player;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "드론";
        infoA="최신식 드론이다. 조금 무거워 보인다.";
        infoB="챙긴다";

        hasOptions = true;

        options = new string[]{"날린다."};
        actionText = new string[]{"어떻게 날리는지 모르겠다"};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Player.actionConditions);
        // if (Player.actionConditions[0]){
        //     actionText[0] = "여기서는 날릴 수 없다";
        // }
    }
}
