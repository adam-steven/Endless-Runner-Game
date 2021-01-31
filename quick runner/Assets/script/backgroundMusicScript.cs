using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusicScript : MonoBehaviour {

    private GameObject lvlCounter;
    private levelCounter lc;

    private int currentLevel = 1;

    public bool mainGame;

    public AudioSource music1;
    public AudioSource music2;

    void Start () {
        lvlCounter = GameObject.FindWithTag("level Counter");
        lc = lvlCounter.GetComponent<levelCounter>();
    }
	
	void Update () {
	
        if(mainGame)
        {
            if(GameObject.FindGameObjectWithTag("Player") && PlayerPrefs.GetInt("TTpause") == 0)
            {

                if (!music1.isPlaying)
                {
                    music1.Play();
                }

                if (lc.level > currentLevel)
                {
                    music1.pitch = music1.pitch + 0.1f;
                    currentLevel += 1;
                }
            }
            else
            {
                music1.Stop();
            }
        }	
	}
}
