using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire01 : NPCInteraction
{

//A일 때 0, B일 때 1, C일 때 2
    private bool[] optionsAdded = new bool[]{false, false, false};

    public Sprite fire00A;
    public Sprite fire00B;
    public Sprite fire00C;
    // Start is called before the first frame update
    void Start()
    {
      NPCName = "횃불 00";
      infoA = "꺼진 횃불이다.";

      hasOptions = false;
      options = new List<string> {};

      fire00A = gameObject.GetComponent<SpriteRenderer>().sprite;


      Player = PlayerObject.GetComponent<PlayerInteraction>();
      Inventory = PlayerObject.GetComponent<PlayerInventory>();


    }

    // Update is called once per frame
    void Update()
    {
      if(Player.actionConditions[4]){
        Player.TriggerEnding(14);
      }
      else if(Player.fireConditions[100]==0){
        gameObject.GetComponent<SpriteRenderer>().sprite = fire00A;

        if(Inventory.contains("성냥")&& !optionsAdded[0]){
          infoA = "꺼진 횃불이다.";
          hasOptions = true;
          addOption("불을 켠다.", "");
          optionsAdded[0]=true;
        }

      }
      else if(Player.fireConditions[100]==1 && !optionsAdded[1]){


        infoA = "불에 타고 있다.";
        hasOptions = true;
        addOption("불을 끈다.", "");
        addOption("불을 더 붙인다.", "");

        optionsAdded[1] = true;
      }
      else if(Player.fireConditions[100]==2 && !optionsAdded[2]){
        gameObject.GetComponent<SpriteRenderer>().sprite = fire00C;
        infoA = "뜨거워보인다.";
        hasOptions = true;
        addOption("불을 끈다.", "");

        optionsAdded[2] = true;
      }

    }

    public override string selectOption(int optionNo)
    {
      Player.optionsBox.SetActive(false);

      if (optionNo == options.IndexOf("불을 켠다.")){
        Player.fireConditions[100]=1;

          options.Remove("불을 켠다.");
          actionText.RemoveAt(optionNo);
          gameObject.GetComponent<SpriteRenderer>().sprite = fire00B;
          optionsAdded[1]=false;
          return "불을 켰다.";


      }

      else if (optionNo == options.IndexOf("불을 더 붙인다.")){
        Player.fireConditions[100]=2;

          options = new List<string> {};
          gameObject.GetComponent<SpriteRenderer>().sprite = fire00C;
          optionsAdded[2]=false;
          return "더 밝아졌다.";

      }

      else if (optionNo == options.IndexOf("불을 끈다.")){
        Player.fireConditions[100]=0;

          options = new List<string> {};
          gameObject.GetComponent<SpriteRenderer>().sprite = fire00A;
          optionsAdded[0] = false;
          return "불이 꺼졌다.";

      }

      return null;
    }







}
