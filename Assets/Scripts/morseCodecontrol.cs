using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class morseCodecontrol : MonoBehaviour
{
	public Canvas escapeBook;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			escapeBook.gameObject.SetActive(false);
		}
	}
}
