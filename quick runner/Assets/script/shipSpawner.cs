using UnityEngine;


public class shipSpawner : MonoBehaviour {

	public GameObject[] ships;


	void Start () {

		Instantiate (ships[PlayerPrefs.GetInt("TTcharacter")], transform.position, transform.rotation);

	}

	void Update () {
	
	}
}