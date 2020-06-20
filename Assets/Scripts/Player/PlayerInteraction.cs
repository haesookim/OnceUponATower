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

	public GameObject infoB;

	public Text doorText;

	public bool dialogueActive;
	public bool NPCActive;

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
	public string endingTitle;

	public Canvas constCanvas;


	//conditions checker;
	public Dictionary<int, bool> actionConditions = new Dictionary<int, bool>{
		{1, false},
		{2, false},
		{3, false},
		{4, false},
		{6, false},
		{7, false},
		{9, false},
		};

	public Dictionary<int, int> fireConditions = new Dictionary<int, int>{
		{100, 0},{101, 0},{102, 0},{103, 0},{104, 0},
		{110, 0},{111, 0},{112, 0},{113, 0},{114, 0},
		{120, 0},{121, 0},{122, 0},{123, 0},{124, 0}

	};

	void Start()
	{
		dialogueCanvas = GameObject.Find("interactionCanvas").GetComponent<Canvas>();
		inventoryCanvas = GameObject.Find("inventoryCanvas").GetComponent<Canvas>();
		doorCanvas = GameObject.Find("DoorCanvas").GetComponent<Canvas>();
		EndingCanvas = GameObject.Find("EndingCanvas").GetComponent<Canvas>();
		constCanvas = GameObject.Find("ConstCanvas").GetComponent<Canvas>();



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
				infoB.SetActive(true);
				infoB.GetComponent<Text>().text = currentObj.infoB;

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
				currentNPC.active = true;
				GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
				GameObject.Find("infoA").GetComponent<Text>().text = currentNPC.infoA;
				infoB.SetActive(false);

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
		else if (col.tag == "dragon" || col.tag == "NPC_dwarf" || col.tag == "BasementTrigger")
		{
			dialogueActive = true;
			NPCActive = true;
			dialogueCanvas.gameObject.SetActive(true);
			currentNPC = col.gameObject.GetComponent<NPCInteraction>();
			currentNPC.active = true;

			GameObject.Find("ObjName").GetComponent<Text>().text = currentNPC.NPCName;
			GameObject.Find("infoA").GetComponent<Text>().text = currentNPC.infoA;

			if (currentNPC.hasOptions)
			{
				for (int i = 0; i < currentNPC.options.Count; i++)
				{
					GameObject newOption = Instantiate(optionItem, optionsParent.transform);
					newOption.transform.GetChild(0).GetComponent<Text>().text = currentNPC.options[i];
					newOption.transform.SetParent(optionsParent.transform, false);
				}
			}

			if (col.tag == "dragon")
			{
				if (!actionConditions[2])
				{
					gameObject.GetComponent<PrincessMove>().enabled = false;
					gameObject.GetComponent<Animator>().enabled = false;
				}
			}

			if (col.tag == "NPC_dwarf" || col.tag == "BasementTrigger")
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
				if (currentObj.itemName == "막대기")
				{
					if (currentObj.gameObject.GetComponent<stickInteraction>().optionselected)
						Destroy(currentObj.gameObject);
				}
			}

			if (col.tag == "NPC")
			{
				currentNPC.active = false;
				if (currentNPC.hasOptions)
				{
					for (int i = 0; i < optionsParent.transform.childCount; i++)
					{
						Destroy(optionsParent.transform.GetChild(i).gameObject);
						currentNPC.optionsVisible = true;
					}
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
		constCanvas.gameObject.SetActive(false);

		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;

		//endingText.text="Ending number "+ endingNo+ " triggered\n";
		// move to scene No. of ending
		if (endingNo == 1)
		{
			endingTitle = "독이 든 사과를 먹다";
			ending = "아니… 당연히 독사과죠…";
		}
		else if (endingNo == 2)
		{
			endingTitle = "프로게이머의 꿈을 키우다";
			ending = "공주는 승부욕이 강하다!! 마스터 티어를 찍으려면 성을 떠날 수 없어요.";
		}

		else if (endingNo == 4)
		{
			endingTitle = "욕쟁이 할머니에게 호되게 혼나다";
			ending = "어른에게 장난 치면 안돼요. 욕쟁이 할머니의 찰진 욕을 들은 공주는 너무 놀란 나머지 심장이 멈춰버리고 말았어요.";
		}
		else if (endingNo == 5)
		{
			endingTitle = "드론의 파편에 급소를 찔리다";
			ending = "싸늘하다.. 드론이 미간에 날아와 꽂힌다...";
		}
		else if (endingNo == 6)
		{
			endingTitle = "맛있는 통구이가 되다";
			ending = "『앗, 뜨거워!』 공주와 왕자는 노릇노릇하게 구워졌어요.";
		}
		else if (endingNo == 7)
		{
			endingTitle = "팅커벨의 거룩한 희생을 기억하다";
			ending = "팅커벨은 하늘의 별이 되었어요.\n공주는 명복을 빌어줬어요.";
		}
		else if (endingNo == 8)
		{
			endingTitle = "왕자에게 황제 자리를 빼앗기다";
			ending = "왕자와 공주는 무사히 성을 빠져나갔어요.\n왕자는 와브바아 왕국의 황제가 되었고, 둘은 만백성의 축복 속에서 결혼을 했답니다.\n공주는 억울했어요.\n저새끼가 가로챘거든요.";
		}
		else if (endingNo == 9)
		{
			endingTitle = "지하감옥에 갇혀있던 공주들을 탈출시키다";
			ending = "모든 공주들은 와브바아 왕국으로 향했어요.\n『안녕히 계세요 여러분~! 우리는 이 세상의 모든 굴레와 속박을 벗어던지고 우리의 행복을 찾아 떠납니다.』\n『여러분도 행복하세요~~~~~』";
		}

		else if (endingNo == 11)
		{
			endingTitle = "솔직한 거울을 만나다";
			ending = "『거울아 거울아, 세상에서 누가 제일 예쁘니?』\n『당연히 왕비님이 가장 아름다우시죠.』\n『이 새끼가?!』\n공주는 화딱지가 나서 기절하고 말았어요.";
		}
		else if (endingNo == 12)
		{
			endingTitle = "난쟁이의 선한 얼굴에 속아 넘어가다";
			ending = "잘 모르는 사람은 따라가면 안돼요…";
		}
		else if (endingNo == 13)
		{
			endingTitle = "백종원의 트러플 오일 파스타를 맛보다";
			ending = "공주는 진정한 천국이 무엇인지 알게 되었어요. 탈출 안 해~";
		}
		else if (endingNo == 14)
		{
			endingTitle = "어린왕자와 여생을 함께하다";
			ending = "『성이 아름다운 것은... 그것이 어딘가에 공주를 감추고 있기 때문이지.』 \n『너를 구하러 왔어. 이제 나와 함께 가자.』 \n\n공주의 SOS 신호를 포착한 어린왕자가 소행성 B612에서 지구로 내려왔어요.\n공주는 그렇게 태양계를 벗어났어요.";
		}
		else if (endingNo == 15)
		{
			endingTitle = "독극물의 맛을 알게 되다";
			ending = "독극물인 거 알았잖아요..!";
		}
		else if (endingNo == 16)
		{
			endingTitle = "인벤토리에 깔리다";
			ending = "엄지공주는 정말 작고 가벼워요!";
		}
		else if (endingNo == 17)
		{
			endingTitle = "옛날 옛적 도와줬던 제비를 만나다";
			ending = "제비가 엄지공주를 태우고 꽃의 나라로 향합니다.";
		}
		else if (endingNo == 18)
		{
			endingTitle = "맥시무스의 말발굽에 치이다";
			ending = "거대해진 맥시무스가 용을 물리쳤어요. \n하지만 너무 커진 맥시무스는 공주와 왕자를 미처 발견하지 못하고…";
		}
		else if (endingNo == 19)
		{
			endingTitle = "스스로 탈출구를 마련하다";
			ending = "힘세고 강한 스테로이드! 만약 내게 물어보면 나는 공주!\n공주는 벽을 부수고 나갔어요. 공주는 자유로운 영혼이에요.";
		}
		else if (endingNo == 20)
		{
			endingTitle = "흔들리지 않는 편안함을 맛보다";
			ending = "공주는 잠에서 헤어나올 수 없었어요. \n그 어떤 왕자가 키스를 하더라도 이건 못 깨어나요. \n너무 달콤해.";
		}
		else if (endingNo == 21)
		{
			endingTitle = "물레의 가시에 손을 찔리다";
			ending = "공주 세계관에서 물레는... 아주 위험한 물건이에요. \n이웃나라 잠자는 숲속의 공주도 물레 한 번 잘못 건드려서 \n100년인가 잤대요.";
		}
		else if (endingNo == 22)
		{
			endingTitle = "강아지를 잃다";
			ending = "강아지에게 사과 씨앗을 주면 안돼요… \n사과 씨앗에는 중독 증상을 유발하는 성분이 있어요. \n강아지를 해쳤다는 사실에 낙담한 공주는 삶의 의욕을 잃었어요.";
		}
		else if (endingNo == 23)
		{
			endingTitle = "퍼피랜드로 향하다";
			ending = "공주의 관심에 즐거워진 멍멍이가 꼬리를 힘차게 흔들었어요. \n멍멍이의 꼬리가 헬리콥터 날개처럼 돌아가면서, \n공주와 댕댕이는 퍼피랜드로 날아갈 수 있었답니다.";
		}
		else if (endingNo == 24)
		{
			endingTitle = "개가 되다";
			ending = "말 그대로 개가 되었어요. 『멍멍!』";
		}
		else if (endingNo == 3)
		{
			endingTitle = "용감한 시민상을 받다";
			ending = "막대기로 용을 찌르다니, 너무나 용감해요. \n비록 공주는 용에게 밟혀 죽었지만 \n소식을 전해 들은 옆나라 코가제 왕국에서 \n공주에게 ‘올해의 용감한 시민상’을 수여했어요.";
		}
		else if (endingNo == 10)
		{
			endingTitle = "용이 불을 뿜다";
			ending = "용은 근육을 좋아해요. \n간에 기별도 안 가는 스테로이드에 너무나 실망했어요.";
		}
		else if (endingNo == 18)
		{
			endingTitle = "탈출에 성공하다";
			ending = "공주는 고소공포증을 이겨내고 무사히 땅에 내려올 수 있었어요. \n가시덩굴을 피해 와브바아 왕국에 돌아간 공주는 \n최정예 군사를 휘동하여 용을 물리쳤답니다.";
		}
		else
		{
			endingTitle = "안채워졌네요 채워주세요";
			ending = "코드 확인용~";
		}
		Debug.Log("Ending number" + endingNo + "triggered");

		GameData.DataToSave.endingsToSave[endingNo - 1] = true;
		GameData.DataToSave.endingTitlesToSave[endingNo - 1] = endingTitle;
		GameData.DataToSave.SaveGame();


		GameObject.Find("EndingText").GetComponent<Text>().text = ending;
		GameObject.Find("EndingTitle").GetComponent<Text>().text = endingTitle;

	}

	void Update()
	{
		//Debug commands to check save functionality
		if (Input.GetKeyDown(KeyCode.I))
		{
			string saveInfo = "Endings seen: [";
			for (int i = 0; i < 21; i++)
			{
				saveInfo = saveInfo + ", " + GameData.DataToSave.endingTitlesToSave[i];
			}
			saveInfo += "]";
			Debug.Log(saveInfo);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			GameData.DataToSave.ResetData();
		}

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
					if (currentNPC.NPCName != "수상한 초상화")
					{
						selectorPos.y = optionsParent.transform.GetChild(selectedOption).transform.position.y;
					}

					if (Input.GetKeyDown(KeyCode.LeftControl))
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
					if (Input.GetKeyDown(KeyCode.LeftControl))
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



				if (Input.GetKeyDown(KeyCode.Z))
				{
					inventory.addItem(currentObj);
					Destroy(currentObj.gameObject);
				}
			}
		}
		else
		{
			dialogueCanvas.gameObject.SetActive(false);
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

			if (Input.GetKeyDown(KeyCode.LeftControl))
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
