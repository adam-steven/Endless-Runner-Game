using UnityEngine;
using System.Collections;

public class quickUnlockClean : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("TTDied", 0);
		PlayerPrefs.SetInt ("TTSurvivedCol", 0);
		PlayerPrefs.SetInt ("TTTrapTripped", 0);
		PlayerPrefs.SetInt ("TTComplete", 0);
		PlayerPrefs.SetInt ("TTDeathCounter", 0);
		PlayerPrefs.SetInt ("TTOutOfFule", 0);
	
	}
}
