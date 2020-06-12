using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public GameObject player;
	public PlayerInteraction interaction;
	public float offset;
	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		interaction = player.GetComponent<PlayerInteraction>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 newPos = this.transform.position;

		float positionOffset = this.transform.position.x - player.transform.position.x;

		// if (positionOffset > offset)
		// {
		// 	newPos.x = player.transform.position.x + offset;

		// 	//newpos =Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		// }
		// else if (positionOffset < -offset)
		// {
		// 	newPos.x = player.transform.position.x - offset;
		// }

		if (player.GetComponent<PlayerInteraction>().teleported)
		{
			newPos.x = 0;
			// if (interaction.currentDoor.positionInfo == "left")
			// {
			// 	newPos.x = player.transform.position.x - offset;
			// }
			// else if (interaction.currentDoor.positionInfo == "right")
			// {
			// 	newPos.x = player.transform.position.x + offset;
			// }
			newPos.y = player.transform.position.y + 1.6f;
			player.GetComponent<PlayerInteraction>().teleported = false;
		}
		this.transform.position = newPos;
	}
}
