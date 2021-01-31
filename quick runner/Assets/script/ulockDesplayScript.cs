using UnityEngine;
using System.Collections;

public class ulockDesplayScript : MonoBehaviour {

	private bool unlockedBro;
	private bool unlockedCraw;
	private bool unlockedSphere;
	private bool unlockedTanker;
	private bool unlockedTheUtitled;
	private bool unlockedTrip;

	private TextMesh tm;

	void Start () {

		tm = GetComponent<TextMesh>();

		if(PlayerPrefs.GetInt("TTDied") == 1)
		{
			unlockedTheUtitled = true;
		}

		if (PlayerPrefs.GetInt("TTSurvivedCol") == 1)
		{
			unlockedCraw = true;
		}

		if (PlayerPrefs.GetInt("TTTrapTripped") == 1)
		{
			unlockedTrip = true;
		}

		if (PlayerPrefs.GetInt("TTComplete") == 1)
		{
			unlockedSphere = true;
		}

		if (PlayerPrefs.GetInt("TTDeathCounter") >= 25)
		{
			unlockedBro = true;
		}

		if (PlayerPrefs.GetInt ("TTOutOfFule") == 1) 
		{
			unlockedTanker = true;
		}
	
	}

	void Update () {

		if (GameObject.FindGameObjectWithTag ("Player")) {
			tm.text = "";
		} 
		else 
		{
			if(PlayerPrefs.GetInt("TTDied") == 1 && !unlockedTheUtitled)
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}

			if (PlayerPrefs.GetInt("TTSurvivedCol") == 1 && !unlockedCraw)
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}

			if (PlayerPrefs.GetInt("TTTrapTripped") == 1 && !unlockedTrip)
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}

			if (PlayerPrefs.GetInt("TTComplete") == 1 && !unlockedSphere)
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}

			if (PlayerPrefs.GetInt("TTDeathCounter") >= 25 && !unlockedBro)
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}

			if (PlayerPrefs.GetInt ("TTOutOfFule") == 1 && !unlockedTanker) 
			{
				tm.text = "NEW CHARACTER UNLOCKED";
			}
		}
	
	}
}
