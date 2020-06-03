using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Sound{
  public string soundName;
  public AudioClip clip;

}
public class SoundManager : MonoBehaviour
{
    public Text Location;
    public string currentLocation;
    private int backgroundNum;
    public bool isPlay = false;


    [Header("사운드 등록")]
    [SerializeField] Sound[] backgroundSounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource backgroundPlayer;

    // Start is called before the first frame update
    void Start()
    {
      backgroundNum = 6;

    }

    void Update(){
      currentLocation = Location.text;
      Debug.Log(currentLocation);


      if(currentLocation == "어두운 숲 속"){
        backgroundNum = 0;
        isPlay = true;
      }
      else if(currentLocation == "주방과 식당"){
        backgroundNum = 1;
        isPlay = true;
      }
      else if(currentLocation == "창고"){
        backgroundNum = 2;
        isPlay = true;
      }
      else if(currentLocation == "정원"){
        backgroundNum = 3;
        isPlay = true;
      }
      else if(currentLocation == "지하감옥"){
        backgroundNum = 4;
        isPlay = true;
      }
      else{
        backgroundNum = 5;
        isPlay = false;
      }

      Debug.Log(backgroundNum);



      PlayBackground(backgroundNum, isPlay);

    }

    public void PlayBackground(int Num, bool Playing){


      if(Playing){
        backgroundPlayer.clip = backgroundSounds[Num].clip;
        Debug.Log("Play");
        backgroundPlayer.Play();
        Debug.Log("소리");
      }




    }
}
