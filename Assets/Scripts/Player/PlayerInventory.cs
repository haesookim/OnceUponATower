using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
	private int inventorySize = 11;
	public GameObject InventoryParent;
	public Dictionary<string, string> inventory = new Dictionary<string, string>();
	public Dictionary<string, Sprite> inventoryImage = new Dictionary<string, Sprite>();
	public Image[] inventoryUIImage;
	public int currentInventoryCount;

	public Image highlight;
	int currenthighlight;

	public bool inventoryUpdate = false;

	public bool inventoryVisible = false;
	public Canvas inventoryCanvas;

	void Start()
	{
		inventoryUIImage = new Image[inventorySize];
		currentInventoryCount = 0;

		for (int i = 0; i < inventorySize; i++)
		{
			inventoryUIImage[i] = InventoryParent.transform.GetChild(i).GetComponent<Image>();
		}
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			inventoryVisible = !inventoryVisible;
			currenthighlight = 0;
		}
		if (inventoryVisible)
		{
			inventoryCanvas.gameObject.SetActive(true);
			gameObject.GetComponent<PrincessMove>().enabled = false;
			gameObject.GetComponent<Animator>().enabled = false;
			if (currentInventoryCount > 0)
			{
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					currenthighlight = (currenthighlight + 1) % currentInventoryCount;
				}
				else if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					currenthighlight = (currenthighlight + currentInventoryCount - 1) % currentInventoryCount;
				}
			}

			Vector3 newpos = highlight.transform.position;
			newpos.x = inventoryUIImage[currenthighlight].transform.position.x;
			highlight.transform.position = newpos;
		}
		else
		{
			inventoryCanvas.gameObject.SetActive(false);
			gameObject.GetComponent<PrincessMove>().enabled = true;
			gameObject.GetComponent<Animator>().enabled = true;
		}



		if (inventoryUpdate)
		{

			int i = 0;
			for (int j = 0; j < inventorySize; j++)
			{
				inventoryUIImage[j].sprite = null;
			}

			foreach (KeyValuePair<string, string> entry in inventory)
			{
				inventoryUIImage[i].sprite = inventoryImage[entry.Key];
				inventoryUIImage[i].color = Color.white;
				i++;
			}
			inventoryUpdate = false;
		}
	}

	public void addItem(InteractableObject item)
	{
		if (currentInventoryCount < inventorySize)
		{
			inventory.Add(item.itemName, item.infoA);
			inventoryImage.Add(item.itemName, item.itemSprite);
			currentInventoryCount++;
			inventoryUpdate = true;
		}
		else
		{
			Debug.Log("Inventory Full!");
		}
	}

	public void removeItem(string itemName)
	{
		if (inventory.ContainsKey(itemName))
		{
			inventory.Remove(itemName);
			inventoryImage.Remove(itemName);
			inventoryUpdate = true;
			currentInventoryCount--;
		}
	}
	public void replaceItem(string itemName, string infoA, Sprite image)
	{
		inventory.Add(itemName, infoA);
		inventoryImage.Add(itemName, image);
		inventoryUpdate = true;
		currentInventoryCount++;
	}
	// check for item
	public bool contains(string itemName)
	{
		if (inventory.ContainsKey(itemName))
		{
			return true;
		}
		return false;
	}
}
