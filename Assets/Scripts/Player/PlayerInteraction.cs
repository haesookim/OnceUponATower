using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
	// Canvas Text interaction
	public Canvas dialogueCanvas;
	public GameObject optionItem;
	public GameObject optionsParent;
	public GameObject optionsBox;
	public GameObject optionSelector;

	public Text doorText;

	private bool dialogueActive;
	private bool NPCActive;

	private InteractableObject currentObj;
	private NPCInteraction currentNPC;

	// for moving across Rooms
	public Canvas doorCanvas;
	public GameObject doorParent;
	private bool doorActive;
	public GameObject doorBox;
	public GameObject doorSelector;
	public bool teleported = false;

	public Door currentDoor;

	//for inventory
	[SerializeField] private PlayerInventory inventory;

	public Canvas inventoryCanvas;
	private int selectedOption = 0;
	private int selectedDoor = 0;

	public Canvas EndingCanvas;
	public string ending;

	//conditions checker;
	public Dictionary<int, bool> actionConditions = new Dictionary<int, bool>{
		{1, false},
		{2, false},
		{3, false},
		{6, false},
		{7, false}
		};

	void Start()
	{
		dialogueCanvas = GameObject.Find("interactionCanvas").GetComponent<Canvas>();
		inventoryCanvas = GameObject.Find("inventoryCanvas").GetComponent<Canvas>();
		doorCanvas = GameObject.Find("DoorCanvas").GetComponent<Canvas>();
		EndingCanvas = GameObject.Find("EndingCanvas").GetComponent<Canvas>();

		inventory = gameObject.GetComponent<PlayerInventory>();

		dialogueCanvas.gameObject.SetActive(false);
		doorCanvas.gameObject.SetActive(false);

	}

	// Enter and Exit Interactable Objects
	// Must be tagged as "interactableObject" or "NPC"
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "interactableObject" || col.tag == "NPC")
		{
			selectedOption = 0;
			dialogueCanvas.gameObject.SetActive(true);
			dialogueActive = true;

			if (col.tag == "interactableObject")
			{
				NPCActive = false;
				currentObj = col.gameObject.GetComponent<InteractableObject>();
				currentObj.active = true;
				GameObject.Find("ObjName").GetComponent<Text>().text = currentObj.itemName;
				GameObject.Find("infoA").GetComponent<Text>().text = currentObj.infoA;
				GameObject.Find("infoB").GetComponent<Text>().text = currentObj.infoB;

				if (currentObj.hasOptions)
				{
					for (int i = 0; i < currentObj.options.Length; i++)
					{
						GameObject newOption = Instantiate(optionItem, optionsParent.transform);
						newOption.transform.GetChild(0).GetComponent<Text>().text = currentObj.options[i];
						newOption.transform.SetParent(optionsParent.transform, false);
					}
				}
			}
			else if (col.tag == "NPC")
			{
				NPCActive = true;
				currentNPC = col.gameObject.GetComponent<NPCInteraction>();
				GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
				GameObject.Find("infoA").GetComponent<Text>().text = currentNPC.infoA;
				GameObject.Find("infoB").GetComponent<Text>().text = "";

				if (currentNPC.hasOptions)
				{
					for (int i = 0; i < currentNPC.options.Count; i++)
					{
						GameObject newOption = Instantiate(optionItem, optionsParent.transform);
						newOption.transform.GetChild(0).GetComponent<Text>().text = currentNPC.options[i];
						newOption.transform.SetParent(optionsParent.transform, false);
					}
				}
			}
		}
		else if (col.tag == "NPC_portrait")
		{
			dialogueActive = true;
			NPCActive = true;
			currentNPC = col.gameObject.GetComponent<NPCInteraction>();
			//GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
		}
		else if (col.tag == "dragon")
		{
			dialogueActive = true;
			NPCActive = true;
			dialogueCanvas.gameObject.SetActive(true);
			currentNPC = col.gameObject.GetComponent<NPCInteraction>();

			GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
			GameObject.Find("infoA").GetComponent<Text>().text = currentNPC.infoA;
			GameObject.Find("infoB").GetComponent<Text>().text = "";

			if (currentNPC.hasOptions)
			{
				for (int i = 0; i < currentNPC.options.Count; i++)
				{
					GameObject newOption = Instantiate(optionItem, optionsParent.transform);
					newOption.transform.GetChild(0).GetComponent<Text>().text = currentNPC.options[i];
					newOption.transform.SetParent(optionsParent.transform, false);
				}
			}

			if (!actionConditions[2])
			{
				gameObject.GetComponent<PrincessMove>().enabled = false;
				gameObject.GetComponent<Animator>().enabled = false;
			}
		}
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "door" && !doorActive)
		{
			selectedDoor = 0;
			doorCanvas.gameObject.SetActive(true);

			doorActive = true;
			currentDoor = col.gameObject.GetComponent<Door>();

			GameObject.Find("DoorName").GetComponent<Text>().text = currentDoor.positionName;

			for (int i = 0; i < currentDoor.goalPosition.Length; i++)
			{
				GameObject newOption = Instantiate(optionItem, doorParent.transform);
				newOption.transform.GetChild(0).GetComponent<Text>().text = currentDoor.goalPosition[i].positionName;
				newOption.transform.SetParent(doorParent.transform, false);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "interactableObject" || col.tag == "NPC" || col.tag == "NPC_portrait" || col.tag == "dragon")
		{
			dialogueActive = false;
			dialogueCanvas.gameObject.SetActive(false);

			if (col.tag == "interactableObject")
			{
				currentObj.active = false;
				if (currentObj.hasOptions)
				{
					for (int i = 0; i < optionsParent.transform.childCount; i++)
					{
						Destroy(optionsParent.transform.GetChild(i).gameObject);
						currentObj.optionsVisible = true;
					}
				}
			}

			if (col.tag == "NPC" && currentNPC.hasOptions)
			{
				for (int i = 0; i < optionsParent.transform.childCount; i++)
				{
					Destroy(optionsParent.transform.GetChild(i).gameObject);
					currentNPC.optionsVisible = true;
				}
			}

		}

		if (col.tag == "door")
		{
			doorActive = false;
			doorCanvas.gameObject.SetActive(false);
			for (int i = 0; i < doorParent.transform.childCount; i++)
			{
				Destroy(doorParent.transform.GetChild(i).gameObject);
			}
		}
	}
	public void TriggerEnding(int endingNo)
	{
		EndingCanvas.gameObject.SetActive(true);
		gameObject.GetComponent<PrincessMove>().enabled = false;
		dialogueCanvas.gameObject.SetActive(false);
		inventoryCanvas.gameObject.SetActive(false);


		//endingText.text="Ending number "+ endingNo+ " triggered\n";
		// move to scene No. of ending
		if (endingNo == 1)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n아니… 당연히 독사과죠…";
		}
		else if (endingNo == 2)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n공주는 승부욕이 강하다!! 마스터 티어를 찍으려면 성을 떠날 수 없답니다.";
		}
		else if (endingNo == 3)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n『엣취!』 백주부가 뿌린 설탕이 코에 들어갔어요. 호흡곤란으로 그만…";
		}
		else if (endingNo == 4)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n『옘병 땀병에 갈아버릴 쑥병에 걸려가지고 땀통이 끊어지면은 끝나는 거고 이 시베리아 벌판에서 얼어죽을 년 같으니! 십장생 같은 년!  옘병 땀병에 그냥, 땀통 끊어지면은 그냥 죽는 거야, 이 년아. 이런 개나리를 봤나! 야, 이 십장생아! 귤 까라 그래! 이 시베리아야! 에라이 썅화차야! 이 시베리아 벌판에서 귤이나 까라!』 ";
		}
		else if (endingNo == 5)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n싸늘하다.. 드론이 미간에 날아와 꽂힌다...";
		}
		else if (endingNo == 6)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n『앗, 뜨거워!』 공주와 왕자는 노릇노릇하게 구워졌어요.";
		}
		else if (endingNo == 7)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n팅커벨은 하늘의 별이 되었어요.\n공주는 명복을 빌어줬어요.";
		}
		else if (endingNo == 8)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n왕자와 공주는 무사히 성을 빠져나갔어요.\n왕자는 와브바아 왕국의 황제가 되었고, 둘은 만백성의 축복 속에서 결혼을 했답니다.\n공주는 억울했어요.\n저새끼가 가로챘거든요.";
		}
		else if (endingNo == 9)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n모든 공주들은 와브바아 왕국으로 향했어요.\n『안녕히 계세요 여러분~! 우리는 이 세상의 모든 굴레와 속박을 벗어던지고 우리의 행복을 찾아 떠납니다.』\n『여러분도 행복하세요~~~~~』";
		}
		else if (endingNo == 10)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n착즙기에 손을 넣었어요. 『오늘은 내가 손가락 요리사~!』";
		}
		else if (endingNo == 11)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n『거울아 거울아, 세상에서 누가 제일 예쁘니?』\n『당연히 왕비님이 가장 아름다우시죠.』\n『이 새끼가?!』\n공주는 화딱지가 나서 기절하고 말았어요.";
		}
		else if (endingNo == 12)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n잘 모르는 사람은 따라가면 안돼요…";
		}
		else if (endingNo == 13)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n공주는 진정한 천국이 무엇인지 알게 되었어요. 탈출 안 해~";
		}
		else if (endingNo == 14)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n 공주의 SOS 신호를 포착한 어린왕자가 내려왔어요.\n『성이 아름다운 것은... 그것이 어딘가에 공주를 감추고 있기 때문이야.』\n공주는 그렇게 태양계를 벗어났어요.";
		}
		else if (endingNo == 15)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n독극물인 걸 알고도 그렇게 죽이고 싶었어요?";
		}
		else if (endingNo == 16)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n엄지공주는 정말 작고 가벼워요!";
		}
		else if (endingNo == 17)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n제비가 엄지공주를 태우고 꽃의 나라로 향합니다.";
		}
		else if (endingNo == 18)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n거대해진 맥시무스가 용을 물리쳤어요. 하지만 너무 커진 맥시무스는 공주와 왕자를 미처 발견하지 못하고…";
		}
		else if (endingNo == 18)
		{
			ending = "Ending NO." + endingNo.ToString() + "\n힘세고 강한 스테로이드! 만약 내게 물어보면 나는 공주!\n공주는 벽을 부수고 나갔어요. 공주는 자유로운 영혼이에요.";
		}
		Debug.Log("Ending number" + endingNo + "triggered");

		GameObject.Find("EndingText").GetComponent<Text>().text = ending;

	}

	void Update()
	{
		if (dialogueActive)
		{
			if (NPCActive)
			{
				if (currentNPC.hasOptions && currentNPC.optionsVisible)
				{
					optionsBox.SetActive(true);
					int coefficient = currentNPC.options.Count;
					Vector3 selectorPos = optionSelector.transform.position;
					if (Input.GetKeyDown(KeyCode.UpArrow))
					{
						selectedOption = (selectedOption + coefficient - 1) % coefficient;
					}
					if (Input.GetKeyDown(KeyCode.DownArrow))
					{
						selectedOption = (selectedOption + 1) % coefficient;
					}
					selectorPos.y = optionsParent.transform.GetChild(selectedOption).transform.position.y;

					if (Input.GetKeyDown(KeyCode.Return))
					{
						string temp = currentNPC.selectOption(selectedOption);
						GameObject.Find("infoA").GetComponent<Text>().text = temp; // code in individual Objects

						GameObject.Find("infoB").GetComponent<Text>().text = "";
						optionsBox.SetActive(false);
						selectorPos.y = optionsParent.transform.position.y;
						currentNPC.optionsVisible = false;
					}
					optionSelector.transform.position = selectorPos;
				}
				else
				{
					optionsBox.SetActive(false);
				}


			}
			else
			{
				// Key bindings for dialogue UI
				if (currentObj.hasOptions && currentObj.optionsVisible)
				{
					optionsBox.SetActive(true);
					Vector3 selectorPos = optionSelector.transform.position;
					int coefficient = currentObj.options.Length;
					if (Input.GetKeyDown(KeyCode.UpArrow))
					{
						selectedOption = (selectedOption + coefficient - 1) % coefficient;
					}
					if (Input.GetKeyDown(KeyCode.DownArrow))
					{
						selectedOption = (selectedOption + 1) % coefficient;
					}
					selectorPos.y = optionsParent.transform.GetChild(selectedOption).transform.position.y;
					if (Input.GetKeyDown(KeyCode.Return))
					{
						GameObject.Find("infoA").GetComponent<Text>().text = currentObj.selectOption(selectedOption);
						GameObject.Find("infoB").GetComponent<Text>().text = "";
						selectorPos.y = optionsParent.transform.position.y;
						optionsBox.SetActive(false);
						currentObj.optionsVisible = false;
					}
					optionSelector.transform.position = selectorPos;
				}
				else
				{
					optionsBox.SetActive(false);
				}



				if (Input.GetKeyDown(KeyCode.Q))
				{
					inventory.addItem(currentObj);
					Destroy(currentObj.gameObject);
				}
			}
		}


		if (doorActive)
		{
			Vector3 selectorPos = doorSelector.transform.position;
			int coefficient = currentDoor.goalPosition.Length;

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				selectedDoor = (selectedDoor + coefficient - 1) % coefficient;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				selectedDoor = (selectedDoor + 1) % coefficient;
			}
			selectorPos.y = doorParent.transform.GetChild(selectedDoor).transform.position.y;

			if (Input.GetKeyDown(KeyCode.Return))
			{
				teleported = true;
				this.transform.position = currentDoor.getDestination(currentDoor.goalPosition[selectedDoor]);
				doorText.text = currentDoor.goalPosition[selectedDoor].positionName;
				selectorPos.y = doorParent.transform.position.y;
			}
			doorSelector.transform.position = selectorPos;
		}
	}
}
