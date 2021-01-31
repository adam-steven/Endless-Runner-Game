using UnityEngine;


public class ship : MonoBehaviour {

    //**// is for unlocks easy search

	private float planePositionX;
	private float acceleration;

	private GameObject cam;
	private cameraScript cm;

	public GameObject explosion;

	public float velocity = 4f;
	public float positionTimeser = 3f;
	public float slowDownSpeed = 2f;
	public float maxAcceleration = 50f;
	public float wallLimmits = 135f;

	public int lives = 3;
    public int MaxLives;

    private GameObject score;
    private scoreCounter sc;
    private int defualScoreMultiplir;
    public int increasedScoreMuliplire;

    public float fule = 100;
    public float fullFule = 100;

    public float fuleDeminishRate;
    private float fuleDeminishRateCounter;

    public float boostedFuleDeminishRate;
    private float boostedFuleDeminishRateCounter;

    private bool boosting;
    
    private Transform spawner;
    private spawnerScript ss;
    public float speedIncrease;

    public GameObject outOfFuleShip;

	public float invinsabilityTimer;
	private float setInvinsabilityTimer;
	public Material normal;
	public Material invinsable;
	public Transform texturedModel;
    private Renderer rend;

    [HideInInspector]
	public float flashTimer = 0.2f;
    //[HideInInspector]
    //public float boostFlashTimer = 0.8f;
    private float setFlashTimer;

    private bool healthFlashing;
	public Texture healthFlash;

	private bool fuleFlashing;
	public Texture fuleFlash;

    private bool boostFlashShown;
    private ParticleSystem bpe;

    public bool ShipTrip; //this variable is just for the ship "Trip" that removes all fule add trap a preasent begining to end

    public AudioSource hitWallSound;
    public AudioSource hitObjectSound;
    public AudioSource hitPowerUpSound;
    public AudioSource boostSound;
    public AudioSource nutralEngineSound;
    public AudioSource boostedEngineSound;

    void Start () {
		cam = GameObject.FindWithTag ("MainCamera");
		cm = cam.GetComponent<cameraScript>();

        score = GameObject.FindWithTag ("needed Counter");
        sc = score.GetComponent<scoreCounter>();

        spawner = GameObject.FindWithTag("spawner").transform;
        ss = spawner.GetComponent<spawnerScript>();

        bpe = ss.boostParticleEmitor.GetComponent<ParticleSystem>();

        bpe.Stop();

        sc.multiplier = increasedScoreMuliplire;

        defualScoreMultiplir = sc.scoreIncrease;

        fuleDeminishRateCounter = fuleDeminishRate;
        fule = fullFule;

        rend = texturedModel.GetComponent<Renderer>();

	}

	void Update () {

		if(PlayerPrefs.GetInt("TTpause") == 0)
		{
			if (ShipTrip) {
				ss.TripIsBeingPlayed = true;
			}

            if (Input.GetButton ("left") && acceleration > -maxAcceleration && planePositionX > -wallLimmits)
			{
				acceleration -= velocity * Time.deltaTime * 2;
			}

			if(Input.GetButton ("right") && acceleration < maxAcceleration && planePositionX < wallLimmits)
			{
				acceleration += velocity * Time.deltaTime * 2;
			}

            //controller
			float rotation = Input.GetAxis("Horizontal");

			if(rotation < -0.2f && acceleration > -maxAcceleration && planePositionX > -wallLimmits)
			{
				acceleration -= velocity * Time.deltaTime * 2;
			}
			
			if(rotation > 0.2f && acceleration < maxAcceleration && planePositionX < wallLimmits)
			{
				acceleration += velocity * Time.deltaTime * 2;
			}
            //controller end

			if((planePositionX >= wallLimmits && acceleration > 0) || (planePositionX <= -wallLimmits && acceleration < 0))
			{
				acceleration = 0;
                cameraScript.ableToTilt = false;
                hitWallSound.Play();
				cm.cameraShakeDurationTimer = cm.cameraWallShakeDuration;
			}
            else
            {
                if (acceleration != 0)
                {
                    cameraScript.ableToTilt = true;
                }
            }

			if((!Input.GetButton ("left") && !Input.GetButton ("right") && rotation > -0.2f && rotation < 0.2f))
			{
				if(acceleration < 0)
				{
					acceleration += slowDownSpeed;
				}

				if(acceleration > 0)
				{
					acceleration -= slowDownSpeed;
				}

				if (acceleration < 1 && acceleration > -1) {
					acceleration = 0f;
				}
			}

			planePositionX += (Time.deltaTime * positionTimeser * acceleration);
			transform.position = new Vector3(planePositionX, transform.position.y, transform.position.z);
			transform.eulerAngles = new Vector3(transform.rotation.x, 180, acceleration);

			if(lives <= 0)
			{
                PlayerPrefs.SetInt("TTDied", 1); //**//
				PlayerPrefs.SetInt("TTDeathCounter", PlayerPrefs.GetInt("TTDeathCounter") + 1); //**//
                cm.cameraShakeDurationTimer = cm.cameraShakeDuration;
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy(gameObject);
			}

            if (PlayerPrefs.GetInt("TTstart") == 1)
            {
                if (Input.GetButton("boost"))
                {
                    boosting = true;
                    fuleDeminishRateCounter = 0;

                    if(!boostFlashShown)
                    {
                        bpe.Play();
                        boostFlashShown = true;
                        boostSound.Play();

                        if (!boostedEngineSound.isPlaying)
                        {
                            nutralEngineSound.Stop();
                            boostedEngineSound.Play();
                        }
                    }
                }
                else
                {
                    boosting = false;
                    bpe.Stop();
                    boostSound.Stop();
                    boostFlashShown = false;
                    boostedFuleDeminishRateCounter = 0;

                    if (!nutralEngineSound.isPlaying && nutralEngineSound.enabled)
                    {
                        nutralEngineSound.Play();
                        boostedEngineSound.Stop();
                    }
                }

                if (!boosting) {
				    fuleDeminishRateCounter -= Time.deltaTime;  
                    if (fuleDeminishRateCounter < 0)
                    {
					    fule -= 1;

                        spawnerScript.worldSpeedIncrease = 0;
					    sc.scoreIncrease = defualScoreMultiplir;
					    sc.timeTwoOnDesplay = false;
					    fuleDeminishRateCounter = fuleDeminishRate;
				    }
				}
                else
                {
					boostedFuleDeminishRateCounter -= Time.deltaTime;
					if (boostedFuleDeminishRateCounter < 0) {

						fule -= 1;

                        spawnerScript.worldSpeedIncrease = speedIncrease;
						sc.scoreIncrease = increasedScoreMuliplire;
						sc.timeTwoOnDesplay = true;
						boostedFuleDeminishRateCounter = boostedFuleDeminishRate;
					}
				}

                if (fule < 0)
                {
                    PlayerPrefs.SetInt("TTOutOfFule", 1); //**//
                    cm.cameraShakeDurationTimer = cm.cameraShakeDuration;
                    Instantiate(outOfFuleShip, transform.position, transform.rotation);
                    Destroy(gameObject);
                }

				if (setInvinsabilityTimer > 0) 
				{
					setInvinsabilityTimer -= Time.deltaTime;
                    rend.material = invinsable;
                }
                else
                {
                    rend.material = normal;
                }
            }
		}
        else
        {
            hitWallSound.Stop();
            hitObjectSound.Stop();
            hitPowerUpSound.Stop();
            boostSound.Stop();
            nutralEngineSound.Stop();
            boostedEngineSound.Stop();
        }

		if (healthFlashing || fuleFlashing) {
			setFlashTimer -= Time.deltaTime;

			if (setFlashTimer <= 0) {
				healthFlashing = false;
				fuleFlashing = false;
            }
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "box" && setInvinsabilityTimer <= 0)
		{
            if(lives > 1)
            {
               PlayerPrefs.SetInt("TTSurvivedCol", 1); //**//
            }

			lives -= 1;

            hitObjectSound.Play();
			setInvinsabilityTimer = invinsabilityTimer;
			cm.cameraShakeDurationTimer = cm.cameraShakeDuration;
		}

		if(other.gameObject.tag == "health")
		{
            if(lives < MaxLives)
            {
				setFlashTimer = flashTimer;
				healthFlashing = true;
                lives += 1;
                hitPowerUpSound.Play();
            }
		}

        if(other.gameObject.tag == "multiplier")
        {
			setFlashTimer = flashTimer;
			fuleFlashing = true;
            fule = fullFule;
            hitPowerUpSound.Play();
        }
    }

	void OnGUI()
	{
		if (healthFlashing) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), healthFlash, ScaleMode.StretchToFill, true, 50f);
		}

		if (fuleFlashing) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fuleFlash, ScaleMode.StretchToFill, true, 50f);
		}
    }
}