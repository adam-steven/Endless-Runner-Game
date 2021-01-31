using UnityEngine;


public class movement : MonoBehaviour {

	private float timeDestroy;

	void Start () {

		timeDestroy = 5;
	}

	void Update () {
	
		if(GameObject.FindGameObjectWithTag("Player") && PlayerPrefs.GetInt("TTpause") == 0)
		{
			transform.Translate(Vector3.right * (spawnerScript.worldSpeed + spawnerScript.worldSpeedIncrease) * Time.deltaTime);

			timeDestroy -= Time.deltaTime;

			if(timeDestroy <= 0)
			{
				Destroy (gameObject);
			}
		}
	}
}
