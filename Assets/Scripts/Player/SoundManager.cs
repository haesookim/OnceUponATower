using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Sound
{
	public string soundName;
	public AudioClip clip;

}
public class SoundManager : MonoBehaviour
{
	public Text Location;
	public string currentLocation;
	public int backgroundNum;
	public bool isPlay = false;
	public int backNumBefore = 5;
	public bool isChanged;


	[Header("사운드 등록")]
	public Sound[] backgroundSounds;

	[Header("브금 플레이어")]
	public AudioSource backgroundPlayer;

	// Start is called before the first frame update
	void Start()
	{
		backgroundNum = 6;

	}

	void Update()
	{
		backNumBefore = backgroundNum;
		currentLocation = Location.text;



		if (currentLocation == "어두운 숲 속")
		{
			backgroundNum = 0;
			isPlay = true;
		}
		else if (currentLocation == "주방과 식당")
		{
			backgroundNum = 1;
			isPlay = true;
		}
		else if (currentLocation == "창고")
		{
			backgroundNum = 2;
			isPlay = true;
		}
		else if (currentLocation == "정원")
		{
			backgroundNum = 3;
			isPlay = true;
		}
		else if (currentLocation == "지하감옥")
		{
			backgroundNum = 4;
			isPlay = true;
		}
		else
		{
			backgroundNum = 5;
			isPlay = false;
		}


		if (backNumBefore != backgroundNum){
			PlayBackground(backgroundNum, isPlay);
		}





	}

	public void PlayBackground(int Num, bool Playing)
	{


		if (Playing)
		{
			backgroundPlayer.clip = backgroundSounds[Num].clip;
			backgroundPlayer.Play();

		}
		else{
			backgroundPlayer.Stop();
		}




	}
}
