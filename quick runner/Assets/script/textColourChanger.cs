using UnityEngine;
using System.Collections;

public class textColourChanger : MonoBehaviour {

    private TextMesh tm;

    public Color baseColour;
    public Color deadColour;

    void Start () {
        tm = GetComponent<TextMesh>();
    }
	
	void Update () {

        if (GameObject.FindGameObjectWithTag("Player") && PlayerPrefs.GetInt("TTpause") == 0)
        {
            tm.color = baseColour;
        }
        else
        {
            tm.color = deadColour;
        }
    }
}
