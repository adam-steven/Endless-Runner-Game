using UnityEngine;


public class cameraScript : MonoBehaviour {

	public GameObject target;
	public float speed;

	public float cameraShakeDuration = 0.5f;
	public float cameraWallShakeDuration = 0.5f;
	[HideInInspector]
	public float cameraShakeDurationTimer;
	public float amplitude = 0.1f;

    public static bool ableToTilt;
    public float currentCameraTilt;
    public float tiltAcceleration;
    public float maxTilt;

	void Update() {

        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            ableToTilt = false;
        }
        

        if (PlayerPrefs.GetInt("TTpause") == 0 )
		{
			if(target)
			{
				if(cameraShakeDurationTimer <= 0)
				{
					float step = speed * Time.deltaTime;
					transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
				}
				else
				{
					transform.position = Vector3.MoveTowards(transform.position, target.transform.position + Random.insideUnitSphere * amplitude, 5000f * Time.deltaTime);
					cameraShakeDurationTimer -= Time.deltaTime;
				}
			}
			else
			{
				if(cameraShakeDurationTimer > 0)
				{
					transform.position = Vector3.MoveTowards(transform.position, target.transform.position + Random.insideUnitSphere * amplitude, 5000f * Time.deltaTime);
					cameraShakeDurationTimer -= Time.deltaTime;
				}
			}

            if (ableToTilt)
            {
                if (Input.GetButton("left") && currentCameraTilt < maxTilt)
                {
                    currentCameraTilt += tiltAcceleration * Time.deltaTime * 2;
                }

                if (Input.GetButton("right") && currentCameraTilt > -maxTilt)
                {
                    currentCameraTilt -= tiltAcceleration * Time.deltaTime * 2;
                }

                //controller
                float rotation = Input.GetAxis("Horizontal");

                if (rotation < -0.2f && currentCameraTilt < maxTilt)
                {
                    currentCameraTilt += tiltAcceleration * Time.deltaTime * 2;
                }

                if (rotation > 0.2f && currentCameraTilt > -maxTilt)
                {
                    currentCameraTilt -= tiltAcceleration * Time.deltaTime * 2;
                }
                //controller end

                if (!Input.GetButton("left") && !Input.GetButton("right") && rotation > -0.2f && rotation < 0.2f)
                {
                    if (currentCameraTilt < 0)
                    {
                        currentCameraTilt += tiltAcceleration * Time.deltaTime * 2;
                    }

                    if (currentCameraTilt > 0)
                    {
                        currentCameraTilt -= tiltAcceleration * Time.deltaTime * 2;
                    }
                }

                transform.eulerAngles = new Vector3(20, 0, currentCameraTilt);
            }
            else
            {
                currentCameraTilt = 0;
                transform.eulerAngles = new Vector3(20, 0, currentCameraTilt);
            }
        }
	}
}
