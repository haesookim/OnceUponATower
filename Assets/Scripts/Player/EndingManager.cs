using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
	public Sprite[] endingImages;

	public Sprite loadEnding(int num)
	{
		if (num == 4 || num == 5 || num == 6 || num == 21)
		{
			//enable animator
		}
		return endingImages[num - 1];
	}
}
