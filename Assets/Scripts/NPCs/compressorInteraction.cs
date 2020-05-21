using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compressorInteraction : NPCInteraction 
{
    // Start is called before the first frame update
    private bool[] itemsAdded = new bool[]{false, false};

    public Sprite applejuiceSprite;
    public Sprite truffleOilSprite;
    void Start()
    {
        NPCName = "착즙기";
        infoA="돌로 만든 착즙기다.";

        hasOptions = true;
        options = new List<string>{"살펴본다."};
        actionText = new List<string>{" "};

        Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.contains("사과") && !itemsAdded[0]){
            addOption("사과를 집어넣는다.","사과즙을 얻었다.");
            Debug.Log(actionText);
            itemsAdded[0]  = true;
        }
        if(Inventory.contains("송로버섯") && !itemsAdded[1]){
            addOption("송로버섯을 집어넣는다.", "트러플 오일을 얻었다.");
            addOption("사과를 집어넣는다.","");
            itemsAdded[0]  = true;
        }
        if(Inventory.contains("송로버섯") && !itemsAdded[1]){
            addOption("송로버섯을 집어넣는다.", "");
            itemsAdded[1] = true;
        }
    }
    public override string selectOption(int optionNo){
        Player.optionsBox.SetActive(false);
        if(optionNo == 0){
            Player.TriggerEnding(10);
            return null;
        } else if(optionNo == options.IndexOf("사과를 집어넣는다.")){
            Inventory.removeItem("사과");
            Inventory.replaceItem("사과즙", "사과를 갈아서 만든 즙이다.", applejuiceSprite);
            return actionText[optionNo];
            options.Remove("사과를 집어넣는다.");
            actionText.RemoveAt(optionNo);
            return "사과즙을 획득했다";
        } else if (optionNo == options.IndexOf("송로버섯을 집어넣는다.")){
            Inventory.removeItem("송로버섯");
            Inventory.replaceItem("트러플 오일", "고소한 향이 나는 트러플 오일이다.", truffleOilSprite);
            options.Remove("송로버섯을 집어넣는다.");
            actionText.RemoveAt(optionNo);
            return "트러플 오일을 획득했다.";
        }
        return null;
    }
}
