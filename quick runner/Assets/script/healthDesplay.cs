using UnityEngine;


public class healthDesplay : MonoBehaviour {

	private GameObject player;
	private ship shp;

	private TextMesh tm;

	void Start () {

	}

	void Update () {

		if(GameObject.FindGameObjectWithTag("Player"))
		{
			if(!player)
			{
				player = GameObject.FindWithTag ("Player");
				shp = player.GetComponent<ship>();
				
				tm = GetComponent<TextMesh>();
			}
			else
			{
				tm.text = "HEALTH : " + shp.lives.ToString();
			}
		}
	}
}
