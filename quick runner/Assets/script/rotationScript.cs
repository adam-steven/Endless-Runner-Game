using UnityEngine;
using System.Collections;

public class rotationScript : MonoBehaviour {

    public float speed;

    public bool x;
    public bool y;
    public bool z;

	void Start () {
	
	}
	
	void Update () {

        if (x)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + (speed * Time.deltaTime), transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (y)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + (speed * Time.deltaTime), transform.eulerAngles.z);
        }

        if (z)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + (speed * Time.deltaTime));
        }
    }
}
