using UnityEngine;
using System.Collections;

public class sceneSpawnScript : MonoBehaviour {

    public GameObject[] obj;

    public float timer;
    private float setTimer;

    void Start () {
        setTimer = Random.Range(0f, timer);
    }
	
	void Update () {
        setTimer -= Time.deltaTime;

        if(setTimer <= 0)
        {
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            Instantiate(obj[Random.Range(0, obj.Length)], rndPosWithin, transform.rotation);

            setTimer = Random.Range(0f, timer);
        }
    }
}
