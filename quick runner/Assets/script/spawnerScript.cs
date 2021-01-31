using UnityEngine;


public class spawnerScript : MonoBehaviour {

	public bool stopSpawning;

	private GameObject lvlCounter;
	private levelCounter lc;

	public GameObject[] boxs1;
	public GameObject[] boxs2;
	public GameObject[] boxs3;
	public GameObject[] boxs4;
	public GameObject[] boxs5;
	public GameObject[] boxs6;
	public GameObject[] boxs7;
	public GameObject[] boxs8;
	public GameObject[] boxs9;
	private int levelComplete;

	public float boxsSpawnDelay;
    public float SpawnDelayMultiplier; 

	private float boxSpawnPositionX = 0;
	private float boxSpawnPositionY = 50;
	private float boxSpawnPositionZ = 1750;

	public static float worldSpeed = 450f;
	public static float worldSpeedIncrease;
    private int savedLevel;


	public float restartDelay;
	public GameObject restartScreen;
	public GameObject restartScreenSpawner;
	private bool spawnedScreen;

	public GameObject pauseScreen;

	public GameObject[] upgrades;
	private float upgradesSpawnDelay;
	public float maxUpgradesDelay = 50;
	public float upgradesSpawnWallLimits = 130;

	public GameObject[] upgradesAndTraps;
	public int minLevelForTraps; 

    private GameObject cam;
    private Camera cm;

    public float startDelay;

	[HideInInspector]
	public bool TripIsBeingPlayed;

    public GameObject boostParticleEmitor;

    void Start () {
		upgradesSpawnDelay = Random.Range(0f, maxUpgradesDelay);

        cam = GameObject.FindWithTag("MainCamera");
        cm = cam.GetComponent<Camera>();

        PlayerPrefs.SetInt("TTstart", 0);

        PlayerPrefs.SetInt("TTpause", 0);

		lvlCounter = GameObject.FindWithTag ("level Counter");
		lc = lvlCounter.GetComponent<levelCounter>();

        savedLevel = lc.level;
    }

	void Update () {

        if(PlayerPrefs.GetInt("TTstart") == 0)
        {
            startDelay -= Time.deltaTime;

            if(startDelay <= 0)
            {
                PlayerPrefs.SetInt("TTstart", 1);
            }
        }

		if(PlayerPrefs.GetInt("TTpause") == 0)
		{
			if(GameObject.FindGameObjectWithTag("Player"))
			{

                cm.cullingMask = (1 << LayerMask.NameToLayer("Default") | (1 << LayerMask.NameToLayer("TransparentFX")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("Water")) | (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("player")));

                Cursor.visible = false;

				upgradesSpawnDelay -= Time.deltaTime;
                boxsSpawnDelay -= Time.deltaTime;

				if(upgradesSpawnDelay <= 0)
				{
					if (minLevelForTraps > lc.level && !TripIsBeingPlayed) {
						Instantiate (upgrades [Random.Range (0, upgrades.Length)], new Vector3 (Random.Range (-upgradesSpawnWallLimits, upgradesSpawnWallLimits), transform.position.y, transform.position.z), transform.rotation);
					} else {
						Instantiate (upgradesAndTraps [Random.Range (0, upgradesAndTraps.Length)], new Vector3 (Random.Range (-upgradesSpawnWallLimits, upgradesSpawnWallLimits), transform.position.y, transform.position.z), transform.rotation);
					}
						upgradesSpawnDelay = Random.Range(0f, maxUpgradesDelay);
				}

                if(savedLevel < lc.level)
                {
                    worldSpeed += 50;
                    savedLevel = lc.level;
                }

				if (boxsSpawnDelay <= 0  && !stopSpawning)
				{
					if(lc.level == 1)
					{
						Instantiate (boxs1[Random.Range(0,boxs1.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 2)
					{
						Instantiate (boxs2[Random.Range(0,boxs2.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 3)
					{
						Instantiate (boxs3[Random.Range(0,boxs3.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 4)
					{
						Instantiate (boxs4[Random.Range(0,boxs4.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 5)
					{
						Instantiate (boxs5[Random.Range(0,boxs5.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 6)
					{
						Instantiate (boxs6[Random.Range(0,boxs6.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 7)
					{
						Instantiate (boxs7[Random.Range(0,boxs7.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 8)
					{
						Instantiate (boxs8[Random.Range(0,boxs8.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level == 9)
					{
						Instantiate (boxs9[Random.Range(0,boxs9.Length)], new Vector3 (boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
					}

					if(lc.level > lc.maxLevel)
					{
						levelComplete = Random.Range (0, 9);

                        switch (levelComplete)
                        {
                            case 0:
                                Instantiate(boxs1[Random.Range(0, boxs1.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 1:
                                Instantiate(boxs2[Random.Range(0, boxs2.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 2:
                                Instantiate(boxs3[Random.Range(0, boxs3.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 3:
                                Instantiate(boxs4[Random.Range(0, boxs4.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 4:
                                Instantiate(boxs5[Random.Range(0, boxs5.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 5:
                                Instantiate(boxs6[Random.Range(0, boxs6.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 6:
                                Instantiate(boxs7[Random.Range(0, boxs7.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 7:
                                Instantiate(boxs8[Random.Range(0, boxs8.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;

                            case 8:
                                Instantiate(boxs9[Random.Range(0, boxs9.Length)], new Vector3(boxSpawnPositionX, boxSpawnPositionY, boxSpawnPositionZ), transform.rotation);
                                break;
                        }
                    }

                    boxsSpawnDelay = (SpawnDelayMultiplier/ (worldSpeed + worldSpeedIncrease));

                }
			}
			else
			{
                Cursor.visible = true;

				restartDelay -= Time.deltaTime;

				if(restartDelay <= 0 && !spawnedScreen)
				{
					Instantiate (restartScreen, restartScreenSpawner.transform.position, restartScreenSpawner.transform.rotation);
                    cm.cullingMask = (1 << LayerMask.NameToLayer("UI"));
                    spawnedScreen = true;
				}
			}
		}
		else
		{
            Cursor.visible = true;

			if(!GameObject.FindGameObjectWithTag("pause screen"))
			{
				Instantiate (pauseScreen, restartScreenSpawner.transform.position, restartScreenSpawner.transform.rotation);
                cm.cullingMask = (1 << LayerMask.NameToLayer("UI"));
            }
		}
	}
}
