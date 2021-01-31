using UnityEngine;
using UnityEngine.SceneManagement;


public class characterSelect : MonoBehaviour {

	public int characterNumber;

	public int level;
	public int backToMenu = 1;

	public int pickNumber;
	
	void Start () {
	
	}

	void OnMouseUp()
	{
		PlayerPrefs.SetInt ("TTcharacter", characterNumber);
		SceneManager.LoadScene(level);
	}

	void Update () {

		if(PlayerPrefs.GetInt("TTwhatPosition") == pickNumber)
		{
			if(Input.GetButton ("start"))
			{
				PlayerPrefs.SetInt ("TTcharacter", characterNumber);
                SceneManager.LoadScene(level);
			}
		}
	
		if(Input.GetButton ("quit"))
		{
			SceneManager.LoadScene(backToMenu);
		}
	}
}
