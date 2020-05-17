using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Freeze rotation
	Rigidbody2D rb;


	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;

	}

	IEnumerator MoveCoroutine()
	{
		vector.Set(Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
		animator.SetFloat("DirX", vector.x);

		while (currentWalkCount < walkCount)
		{

			transform.Translate(vector.x * speed, 0, 0);
			animator.SetBool("Walking", true);
			currentWalkCount++;
			yield return new WaitForSeconds(0.01f);

		}
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
