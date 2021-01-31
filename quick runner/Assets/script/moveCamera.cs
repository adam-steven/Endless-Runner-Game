using UnityEngine;


public class moveCamera : MonoBehaviour {

	public bool right;
	public bool left;

	public GameObject[] positions;

	public int minPosition;
	public int maxPosition;

    public float controllerDelay = 0.2f;
    private float setControllerDelay;

    public bool camer;

	void Start () {
		PlayerPrefs.SetInt("TTwhatPosition", 0);

        setControllerDelay = controllerDelay;

    }
	
	void OnMouseUp()
{
		if(right && PlayerPrefs.GetInt("TTwhatPosition") < maxPosition)
		{
			PlayerPrefs.SetInt("TTwhatPosition", PlayerPrefs.GetInt("TTwhatPosition") + 1);
		}
		
		if(left && PlayerPrefs.GetInt("TTwhatPosition") > minPosition)
		{
			PlayerPrefs.SetInt("TTwhatPosition", PlayerPrefs.GetInt("TTwhatPosition") - 1);
		}
	}

	void Update () {

        setControllerDelay -= Time.deltaTime;

		float rotation = Input.GetAxis("Horizontal");

		if(right && (Input.GetButtonUp ("right") || (rotation > 0.5f && setControllerDelay < 0)))
		{
            if (PlayerPrefs.GetInt("TTwhatPosition") < maxPosition)
            {
                PlayerPrefs.SetInt("TTwhatPosition", PlayerPrefs.GetInt("TTwhatPosition") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("TTwhatPosition", minPosition);
            }

            setControllerDelay = controllerDelay;
        }
		
		if(left && (Input.GetButtonUp ("left") || (rotation < -0.5f && setControllerDelay < 0)))
		{
            if (PlayerPrefs.GetInt("TTwhatPosition") > minPosition)
            {
                PlayerPrefs.SetInt("TTwhatPosition", PlayerPrefs.GetInt("TTwhatPosition") - 1);
            }
            else
            {
                PlayerPrefs.SetInt("TTwhatPosition", maxPosition);
            }
            setControllerDelay = controllerDelay;
        }

        //if (setControllerDelay < 0)
        //{
        //    setControllerDelay = controllerDelay;
        //}

        if (camer)
		{
			transform.position = positions[PlayerPrefs.GetInt("TTwhatPosition")].transform.position;
		}
	}
}
