using UnityEngine;
using System.Collections;

public class outOfFuelShipScript : MonoBehaviour {

    public float speed = 100;
	void Start () {
	
	}
	
	
	void Update () {

        speed -= Time.deltaTime;

        transform.Translate(Vector3.back * (speed) * Time.deltaTime);

    }
}
