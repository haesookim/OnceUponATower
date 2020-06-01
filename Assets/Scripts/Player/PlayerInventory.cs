using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
	private int inventorySize = 13;
	public GameObject InventoryParent;
	public Dictionary<string, string> inventory = new Dictionary<string, string>();
	public Dictionary<string, Sprite> inventoryImage = new Dictionary<string, Sprite>();
	public Image[] inventoryUIImage;
	public int currentInventoryCount;

	public bool inventoryUpdate = false;

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
		if (inventoryUpdate)
		{
			int i = 0;
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
		}
	}
	public void replaceItem(string itemName, string infoA, Sprite image)
	{
		inventory.Add(itemName, infoA);
		inventoryImage.Add(itemName, image);
		inventoryUpdate = true;
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
