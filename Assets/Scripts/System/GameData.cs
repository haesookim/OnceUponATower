﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GameData
{

	public static class DataToSave
	{
		public static bool[] endingsToSave = Enumerable.Repeat(false, 27).ToArray();
		public static string[] endingTitlesToSave = Enumerable.Repeat("?", 27).ToArray();

		public static void SaveGame()
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath
						 + "/MySaveData.dat");
			EndingData data = new EndingData();
			data.endingSeen = endingsToSave;
			data.endingTitles = endingTitlesToSave;

			bf.Serialize(file, data);
			file.Close();
			Debug.Log("Game data saved!");
		}
		public static void LoadGame()
		{
			if (File.Exists(Application.persistentDataPath
						   + "/MySaveData.dat"))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file =
						   File.Open(Application.persistentDataPath
						   + "/MySaveData.dat", FileMode.Open);
				EndingData data = (EndingData)bf.Deserialize(file);
				file.Close();
				endingsToSave = data.endingSeen;
				endingTitlesToSave = data.endingTitles;
				Debug.Log("Game data loaded!");
			}
			else
			{
				//endingsToSave = Enumerable.Repeat(false, 21).ToArray();
				//Debug.LogError("no data to load!");
				endingsToSave = Enumerable.Repeat(false, 27).ToArray();
				endingTitlesToSave = Enumerable.Repeat("?", 27).ToArray();
			}
		}

		public static void ResetData()
		{
			if (File.Exists(Application.persistentDataPath
						  + "/MySaveData.dat"))
			{
				File.Delete(Application.persistentDataPath
								  + "/MySaveData.dat");
				Debug.Log("Data reset complete!");
			}
			else
				Debug.LogError("No save data to delete.");
		}
	}
	[System.Serializable]
	class EndingData
	{

		public bool[] endingSeen; //= Enumerable.Repeat(false, 21).ToArray();
		public string[] endingTitles; //= Enumerable.Repeat("?", 21).ToArray();

	}
}
// } EndingGallery : MonoBehaviour
// {
// 	// Start is called before the first frame update
// 	void Start()
// 	{

// 	}

// 	// Update is called once per frame
// 	void Update()
// 	{

// 	}
// }
