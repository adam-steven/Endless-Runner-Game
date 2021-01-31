using UnityEngine;

public class randomSpawn : MonoBehaviour {

	public GameObject ObjectToSpawn;   
	
	private int amountOfWallsToSpawn;
	private int spawnedWallCounter;

	public int minRange = 50;
	public int maxRange = 300;

	private GameObject lvlCounter;
	private levelCounter lc;

	void Start () {
		lvlCounter = GameObject.FindWithTag ("level Counter");
		lc = lvlCounter.GetComponent<levelCounter>();

		amountOfWallsToSpawn = Random.Range(minRange, maxRange * lc.level);
	}

	void Update () {


		while(amountOfWallsToSpawn > spawnedWallCounter)
		{
			Vector3 rndPosWithin;
			rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
			Instantiate(ObjectToSpawn, rndPosWithin, transform.rotation);   
			
			spawnedWallCounter += 1;
		}
	}
}
