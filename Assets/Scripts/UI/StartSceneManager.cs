using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
	public GameObject startButton;
	public GameObject galleryButton;
	public GameObject highlight;

	private int selectedOption = 0;
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

	void Update()
	{
		Vector3 selectorPos = highlight.transform.position;
		int coefficient = 2;

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			selectedOption = (selectedOption + coefficient - 1) % coefficient;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			selectedOption = (selectedOption + 1) % coefficient;
		}

		if (selectedOption == 0)
		{
			selectorPos.y = startButton.transform.position.y - 0.1f;
		}
		else
		{ selectorPos.y = galleryButton.transform.position.y - 0.1f; }

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (selectedOption == 0)
			{
				loadPlay();
			}
			else
			{
				loadGallery();
			}
		}
		highlight.transform.position = selectorPos;
	}
}
