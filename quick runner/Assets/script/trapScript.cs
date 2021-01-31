using UnityEngine;
using System.Collections;

public class trapScript : MonoBehaviour {

    //**// is for unlocks easy search

    public GameObject ExtendedObject;


	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerPrefs.SetInt("TTTrapTripped", 1); //**//
            Instantiate (ExtendedObject, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
