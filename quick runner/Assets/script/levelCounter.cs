using UnityEngine;


public class levelCounter : MonoBehaviour {
    //**// is for unlocks easy search

    //[HideInInspector]
    public int level = 1;
	public int maxLevel = 10;
	public float scoreToNextLevel;

	[HideInInspector]
	public bool levelComplete;

	public Transform levelUpText;
	private TextMesh lutm;
	public float levelUpDeplayTimer;
	private float setLevelUpDeplayTimer;
    private GameObject player; //this is for the text desplaying the fule is low
    private ship shp;

    //private TextMesh tm;

	void Start () {
		//tm = GetComponent<TextMesh>();
		lutm = levelUpText.GetComponent<TextMesh>();

		setLevelUpDeplayTimer = levelUpDeplayTimer;
		levelUpDeplayTimer = 0;

    }

	void Update () {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (!player)
            {
                player = GameObject.FindWithTag("Player");
                shp = player.GetComponent<ship>();
            }
        }

		if (player && PlayerPrefs.GetInt ("TTpause") == 0) {

			if (PlayerPrefs.GetInt ("TTsetCounter") > scoreToNextLevel && !levelComplete) {
				if (level < maxLevel) {
					level += 1;
					levelUpDeplayTimer = setLevelUpDeplayTimer;
					scoreToNextLevel = scoreToNextLevel + (100 * (level - 1));
				} else {
					PlayerPrefs.SetInt ("TTComplete", 1); //**//
					levelUpDeplayTimer = setLevelUpDeplayTimer;
					level += 1;
					levelComplete = true;
				}
			}

			//if (!levelComplete) {
			//	tm.text = "LEVEL : " + level.ToString ();
			//} else {
			//	tm.text = "LEVEL COMPLETE";
			//}

			if (levelUpDeplayTimer > 0) {
				if (!levelComplete) {
					lutm.text = "LEVEL " + level.ToString();
					levelUpDeplayTimer -= Time.deltaTime;
				} else {
					lutm.text = "LEVELS COMPLETE";
					levelUpDeplayTimer -= Time.deltaTime;
				}
			} else {

				if (shp.fule <= 15) {
					lutm.text = "ENERGY LOW";
				} else {
					lutm.text = "";
				}
			}
		}
        else
        {
            if (!levelComplete)
            {
                lutm.text = "LEVEL " + level.ToString();
            }
            else
            {
                lutm.text = "LEVELS COMPLETE";
            }
        }
    }
}
