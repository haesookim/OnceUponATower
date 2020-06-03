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

	public Image highlight;
	int highlightXposOffset = 7;
	int highlightYposOffset = 14;

	int movingOffset = 150;

	GameObject[] GalleryOptions = new GameObject[21];
	public GameObject galleryParent;

	public Camera Main;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < 21; i++)
		{
			GalleryOptions[i] = galleryParent.transform.GetChild(i).gameObject;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow) && endingNo < endingCount - 1)
		{
			endingNo++;
			galleryParent.transform.Translate(new Vector3(-movingOffset, 0, 0));
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && endingNo > 0)
		{
			endingNo--;
			galleryParent.transform.Translate(new Vector3(movingOffset, 0, 0));
		}
		Vector3 newpos = highlight.transform.position;
		newpos.x = GalleryOptions[endingNo].transform.position.x + highlightXposOffset;
		newpos.y = GalleryOptions[endingNo].transform.position.y + highlightYposOffset;
		highlight.transform.position = newpos;



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
