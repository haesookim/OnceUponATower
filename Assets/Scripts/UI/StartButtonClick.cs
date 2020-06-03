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
		SceneManager.LoadScene(ScreenName);
		GameData.DataToSave.LoadGame();
	}
}
