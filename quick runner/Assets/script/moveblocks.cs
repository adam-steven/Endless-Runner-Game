using UnityEngine;


public class moveblocks : MonoBehaviour {

	private GameObject cam;
	private cameraScript cm;

	public bool rotating;
	public bool x;
	public bool y;
	public bool z;
	public float rotationSpeedMultipliter;

	public bool moveDown;
	public float moveDownSpeedMultiplier = 0.14f;

	public bool moveForward;
	private bool shaken;

	public float positionlimit;
	public float speed;

	public AudioSource lostEnergy;


	void Start () {
		cam = GameObject.FindWithTag ("MainCamera");
		cm = cam.GetComponent<cameraScript>();

	}
	

	void Update () {

		if(PlayerPrefs.GetInt("TTpause") == 0 && GameObject.FindGameObjectWithTag("Player"))
		{
			if(moveDown)
			{
				if (transform.position.y > positionlimit) {
					transform.Translate (Vector3.down * (moveDownSpeedMultiplier * spawnerScript.worldSpeed) * Time.deltaTime);
				} 
				else 
				{
					if (!shaken) 
					{
						cm.cameraShakeDurationTimer = cm.cameraWallShakeDuration;
                        if (lostEnergy)
                        {
                            lostEnergy.Play();
                        }
						shaken = true;
					}
				}
			}

			if(moveForward)
			{
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}

			if (rotating)
			{
				if (x)
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x + ((rotationSpeedMultipliter * spawnerScript.worldSpeed) * Time.deltaTime), transform.eulerAngles.y, transform.eulerAngles.z);
				}

				if (y)
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + ((rotationSpeedMultipliter * spawnerScript.worldSpeed) * Time.deltaTime), transform.eulerAngles.z);
				}

				if (z)
				{
					transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + ((rotationSpeedMultipliter * spawnerScript.worldSpeed) * Time.deltaTime));
				}
			}
		}
	}
}
