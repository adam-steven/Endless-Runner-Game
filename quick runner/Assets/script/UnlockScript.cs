using UnityEngine;
using System.Collections;

public class UnlockScript : MonoBehaviour {

    public bool diedOnceLock;
    public bool survivedACollisionLock;
    public bool trapTrippedLock;
    public bool gameCompleteLock;
	public bool deathCounterLock;
	public bool outOfFuleLock;

    public GameObject UnlockedShip;

	void Start () {
	
	}
	
	void Update () {
	
        if(diedOnceLock && PlayerPrefs.GetInt("TTDied") == 1)
        {
            Instantiate(UnlockedShip);
            Destroy(gameObject);
        }

        if (survivedACollisionLock && PlayerPrefs.GetInt("TTSurvivedCol") == 1)
        {
            Instantiate(UnlockedShip);
            Destroy(gameObject);
        }

        if (trapTrippedLock && PlayerPrefs.GetInt("TTTrapTripped") == 1)
        {
            Instantiate(UnlockedShip);
            Destroy(gameObject);
        }

        if (gameCompleteLock && PlayerPrefs.GetInt("TTComplete") == 1)
        {
            Instantiate(UnlockedShip);
            Destroy(gameObject);
        }

		if (deathCounterLock && PlayerPrefs.GetInt("TTDeathCounter") >= 25)
		{
			Instantiate(UnlockedShip);
			Destroy(gameObject);
		}

		if (outOfFuleLock && PlayerPrefs.GetInt ("TTOutOfFule") == 1) 
		{
			Instantiate(UnlockedShip);
			Destroy(gameObject);
		}
    }
}

/// the untitled unlock after first death      PlayerPrefs.SetInt("TTDied", 1);
/// craw unlock by surviving a collision       PlayerPrefs.SetInt("TTSurvivedCol", 1);
/// trip unlock tripping a trap                PlayerPrefs.SetInt("TTTrapTripped", 1);
/// sphere get to level complete               PlayerPrefs.SetInt("TTComplete", 1);
//PlayerPrefs.SetInt("TTOutOfFule", 1);