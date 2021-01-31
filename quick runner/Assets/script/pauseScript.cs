using UnityEngine;


public class pauseScript : MonoBehaviour {

	public bool pauseScreen;

	void Update () {

		if(Input.GetButtonDown ("pause") && !pauseScreen && GameObject.FindGameObjectWithTag("Player"))
		{
			if(PlayerPrefs.GetInt("TTpause") == 0)
			{
				PlayerPrefs.SetInt("TTpause", 1);
			}
			else
			{
				PlayerPrefs.SetInt("TTpause", 0);
			}
		}

		if(pauseScreen && PlayerPrefs.GetInt("TTpause") == 0)
		{
			Destroy(gameObject);
		}
	}
}
