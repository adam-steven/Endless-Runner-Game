using UnityEngine;


public class scoreCounter : MonoBehaviour {

	public bool best;

	private TextMesh tm;

	private int counter;

	public float timer;
	private float setTimer;

	public int scoreIncrease = 1;

	[HideInInspector]
	public float multiplier;

	[HideInInspector]
	public bool timeTwoOnDesplay;

	void Start () {
		tm = GetComponent<TextMesh>();

		counter = 0;
        PlayerPrefs.SetInt("TTsetCounter", counter);

        setTimer = timer;
	}

	void Update () {

		if(!best) 
		{
			if(GameObject.FindGameObjectWithTag("Player") && PlayerPrefs.GetInt("TTpause") == 0 && PlayerPrefs.GetInt("TTstart") == 1)
            {
				setTimer -= Time.deltaTime;

				if(setTimer <= 0)
				{
					counter += scoreIncrease;
					setTimer = timer;
				}

				PlayerPrefs.SetInt ("TTsetCounter", counter);

				if(!timeTwoOnDesplay)
				{
					tm.text = counter.ToString ();
				}
				else
				{
					tm.text = counter.ToString() + "x" + multiplier.ToString();
				}
			}
		}

		if(best)
		{
			if(PlayerPrefs.GetInt("TTsetCounter") > PlayerPrefs.GetInt("TTbestCounter") && !GameObject.FindGameObjectWithTag("Player"))
			{
				PlayerPrefs.SetInt ("TTbestCounter", PlayerPrefs.GetInt("TTsetCounter"));
			}
			
			tm.text = "BEST : " + PlayerPrefs.GetInt("TTbestCounter").ToString();
		}
	}
}
