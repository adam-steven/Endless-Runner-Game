using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

	public bool fullQuit;
	public int level;
    public bool pauseButton;

    public Color baseColour;
	public Color roloverColour;

	private string[] names; //names of all controllers plugged in
	public bool contollerSelectionCounter;
	public int textOrderNumber; //this is for controller selection

    public int minControllerNumber;
    public int maxControllerNumber;

    public float controllerDelay = 0.2f;
	private float setControllerDelay;

	private AudioSource snd;
    private bool controllerMadeSound;

    private TextMesh tm;
    private string orignalText;

    void Start() {
        GetComponent<Renderer>().material.color = baseColour;
        setControllerDelay = controllerDelay;
        if (contollerSelectionCounter) {
            PlayerPrefs.SetInt("TTnttco", 0);
        }

		if (gameObject.GetComponent<AudioSource>()) {
			snd = gameObject.GetComponent<AudioSource> ();
		}

        tm = GetComponent<TextMesh>();
        orignalText = tm.text;
    }

	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = roloverColour;

        if (snd)
        {
            snd.Play();
        }

        tm.text = ">" + orignalText + "<";
    }
	
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color =  baseColour;
        tm.text = orignalText;

    }

	void OnMouseUp()
	{
        if (snd)
        {
            snd.Play();
        }

        if (fullQuit)
		{
			Application.Quit ();
		}
		else
		{
            if (pauseButton)
            {
                PlayerPrefs.SetInt("TTpause", 0);
            }
            else
            {
                SceneManager.LoadScene(level);
            }    
		}
	}

	void Update () {

		names = Input.GetJoystickNames();

		if (Input.GetJoystickNames().Length > 0) {
			if (names [0] != "") {
				if (contollerSelectionCounter) 
				{
					setControllerDelay -= Time.deltaTime;
					float rotation = Input.GetAxis("Vertical");

					if ((rotation > 0.5f && setControllerDelay < 0)) 
					{
                        if (PlayerPrefs.GetInt("TTnttco") < maxControllerNumber)
                        {
                            PlayerPrefs.SetInt("TTnttco", PlayerPrefs.GetInt("TTnttco") + 1);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("TTnttco", minControllerNumber);
                        }
                        setControllerDelay = controllerDelay;
                    }

					if ((rotation < -0.5f && setControllerDelay < 0)) 
					{
                        if (PlayerPrefs.GetInt("TTnttco") > minControllerNumber)
                        {
                            PlayerPrefs.SetInt("TTnttco", PlayerPrefs.GetInt("TTnttco") - 1);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("TTnttco", maxControllerNumber);
                        }
                        setControllerDelay = controllerDelay;
                    }
				}

                if(PlayerPrefs.GetInt("TTnttco") == textOrderNumber)
                {
                    GetComponent<Renderer>().material.color = roloverColour;
                    tm.text = ">" + orignalText + "<";

                    if (snd && !controllerMadeSound)
                    {
                        snd.Play();
                        controllerMadeSound = true;
                    }

                    if (Input.GetButtonUp("start"))
                    {
                        if (snd)
                        {
                            snd.Play();
                        }

                        if (fullQuit)
                        {
                            Application.Quit();
                        }
                        else
                        {
                            if (pauseButton)
                            {
                                PlayerPrefs.SetInt("TTpause", 0);
                            }
                            else
                            {
                                SceneManager.LoadScene(level);
                            }
                        }
                    }
                }
                else
                {
                    GetComponent<Renderer>().material.color = baseColour;
                    tm.text = orignalText;
                    controllerMadeSound = false;
                }
			} 
		} 
	}
}
