using UnityEngine;
using System.Collections;

public class timeDestroyScript : MonoBehaviour {

    public float timeTillDestroy;

	void Start () {
	
	}
	
	void Update () {

        timeTillDestroy -= Time.deltaTime;

        if(timeTillDestroy < 0)
        {
            Destroy(gameObject);
        }
    }
}
