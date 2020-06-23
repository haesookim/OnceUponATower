using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameData;
using UnityEngine.SceneManagement;

public class StartButtonClick : MonoBehaviour
{
	public string ScreenName;
	void OnMouseDown()
	{
		GameData.DataToSave.LoadGame();
		SceneManager.LoadScene(ScreenName);

	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
				OnMouseDown();
		}

	}
}
