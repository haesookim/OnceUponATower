using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
	public void loadGallery()
	{
		GameData.DataToSave.LoadGame();
		SceneManager.LoadScene("GalleryScene");
	}

	public void loadPlay()
	{
		GameData.DataToSave.LoadGame();
		SceneManager.LoadScene("StartText");
	}
}
