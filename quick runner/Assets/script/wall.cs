using UnityEngine;


public class wall : MonoBehaviour {

	private float length;

	public float desieredLength = 2000;

	public float increaseRate = 2000;

	void Start () {
	
	}

	void Update () {

		if(PlayerPrefs.GetInt("TTpause") == 0)
		{
			if(length <= desieredLength)
			{
			length += (Time.deltaTime * increaseRate);
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, length);
			}
		}
	}
}
