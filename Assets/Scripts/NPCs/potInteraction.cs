using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potInteraction : NPCInteraction
{
    // Start is called before the first frame update

    private int hitCount = 0;

    public bool specialcondition;
    public bool collectedPoison;

    public Sprite originalPot;
    public Sprite brokenPot;
    public Sprite poisonSprite;
    void Start()
    {
        NPCName="항아리";
        infoA = "단단한 항아리다.";

        hasOptions = false;

        options = new List<string>{"친다"};
        actionText = new List<string>{"막대기로 항아리를 쳤다. 이 정도로는 부서지지 않는 것 같다."};

        originalPot = gameObject.GetComponent<SpriteRenderer>().sprite;

        Player = PlayerObject.GetComponent<PlayerInteraction>();
        Inventory = PlayerObject.GetComponent<PlayerInventory>();
    }


    // Update is called once per frame
    void Update()
    {
        changeSprite();
        if (Inventory.contains("막대기") && hitCount < 4){
            hasOptions = true;
        }
        if (hitCount == 4){
            hasOptions = false;
            options[0] = "살펴 본다";
            actionText[0] = "두꺼비가 독을 내뿜었다!";

            gameObject.GetComponent<SpriteRenderer>().sprite = brokenPot;
        }

        if(Player.teleported && !collectedPoison){
            System.Random rand = new System.Random();
            int choice = rand.Next(10);
            if (choice < 7){
                specialcondition = false;
            } else{
                specialcondition = true;
            }
        } else {
            specialcondition = false;
        }

        if (!specialcondition){
            infoA = "부서진 항아리다.";
            hasOptions = false;
        } else {
            infoA = "부서진 항아리다. 두꺼비가 붙어 있다.";
            hasOptions = true; 
        }
    }

    public override string selectOption(int optionNo){
        if (optionNo == 0 && specialcondition){
            Inventory.replaceItem("독극물", "두꺼비가 내뱉은 독이다.", poisonSprite);
            collectedPoison = true;
        }
        Player.optionsBox.SetActive(false);
        return actionText[optionNo];
    }
}
