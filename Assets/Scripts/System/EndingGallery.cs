using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGallery : MonoBehaviour
{
	private int endingNo = 0;
	private int endingCount = 21;

	public Text endingTitle;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow) && endingNo < endingCount)
		{
			endingNo++;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && endingNo > 0)
		{
			endingNo--;
		}
		endingTitle.text = GameData.DataToSave.endingTitlesToSave[endingNo];
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
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("StartScene");
		}
	}
}
