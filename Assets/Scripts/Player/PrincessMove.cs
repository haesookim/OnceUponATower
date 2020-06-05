using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WalkSound{
	public string soundName;
	public AudioClip clip;
}

public class PrincessMove : MonoBehaviour
{
  //Basic Movement
	public float speed;
	private Vector3 vector;


	public int walkCount;
	private int currentWalkCount;

	public bool canMove = true;
	public bool coroutineActive = true;

	private Animator animator;

	public WalkSound[] walkingSound;
	public AudioSource walkPlayer;

	public Text Location;
	public string currentLocation;
	public int backgroundNum = 0;
	public bool isPlay = false;
	public int backNumBefore = 0;
	public bool isChanged;



	// Freeze rotation
	Rigidbody2D rb;


	void Start()
	{
		animator = GetComponent<Animator>();

		rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		backgroundNum = 0;


	}

	void Update(){

	currentLocation = Location.text;


	if (currentLocation == "어두운 숲 속"){
			backgroundNum = 2;
	}
	else if (currentLocation == "정원"){
			backgroundNum = 3;
	}
	else if(currentLocation=="1층 복도" || currentLocation=="2층 복도" || currentLocation=="0층 복도" ||currentLocation == "지하감옥"){
		backgroundNum =1;
	}
	else{
		backgroundNum=0;
	}
	walkPlayer.clip = walkingSound[backgroundNum].clip;
}

	IEnumerator MoveCoroutine()
	{
		vector.Set(Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
		animator.SetFloat("DirX", vector.x);




		walkPlayer.Play();
		while (currentWalkCount < walkCount)
		{


			transform.Translate(vector.x * speed, 0, 0);
			animator.SetBool("Walking", true);
			currentWalkCount++;
			yield return new WaitForSeconds(0.01f);



		}
		walkPlayer.Stop();

		currentWalkCount = 0;
		coroutineActive = true;
	}



	void FixedUpdate()
	{

		if (canMove)
		{
			if (coroutineActive)
			{
				if (Input.GetAxis("Horizontal") != 0)
				{
					coroutineActive = false;
					StartCoroutine(MoveCoroutine());
				}
				else
				{
					animator.SetBool("Walking", false);
				}
			}
		}
		else
		{
			StopCoroutine(MoveCoroutine());
			animator.SetBool("Walking", false);
		}
	}
}
