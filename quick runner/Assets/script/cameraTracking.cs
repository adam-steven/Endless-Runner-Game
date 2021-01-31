using UnityEngine;


public class cameraTracking : MonoBehaviour {

	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	

	void Update () {
	
		if (GameObject.FindGameObjectWithTag ("Player") && PlayerPrefs.GetInt ("TTpause") == 0) 
		{
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z); 
		}
	}
}
