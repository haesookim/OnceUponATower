using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGallery : MonoBehaviour
{
	private int endingNo = 0;
	private int endingCount = 24;

	public Text endingTitle;

	public Image highlight;
	int highlightXposOffset = 7;
	int highlightYposOffset = 14;

	int movingOffset = 280;
	int seenCount = 0;

	GameObject[] GalleryOptions;
	public GameObject galleryParent;
	public Image[] GalleryImages;
	public Sprite[] endingImages;

	public Camera Main;
	public Text count;

	// Start is called before the first frame update
	void Start()
	{
		GalleryOptions = new GameObject[endingCount];
		for (int i = 0; i < endingCount; i++)
		{
			GalleryOptions[i] = galleryParent.transform.GetChild(i).gameObject;
			//GalleryImages[i] = (Image)GalleryOptions[i].transform.GetChild(0).gameObject;
			if (GameData.DataToSave.endingsToSave[i])
			{
				seenCount++;
				GalleryImages[i].sprite = endingImages[i];
			}
		}
		endingNo = GameData.DataToSave.lastSeenEnding;
		count.text = seenCount + count.text;
		galleryParent.transform.Translate(new Vector3(-movingOffset * endingNo, 0, 0));
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
			for (int i = 0; i < endingCount; i++)
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
