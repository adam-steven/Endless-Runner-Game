using UnityEngine;
using System.Collections;

public class fuleDesplay : MonoBehaviour {

    private GameObject player;
    private ship shp;

    private TextMesh tm;

    void Start()
    {

    }

    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (!player)
            {
                player = GameObject.FindWithTag("Player");
                shp = player.GetComponent<ship>();

                tm = GetComponent<TextMesh>();
            }
            else
            {
                tm.text = "ENERGY : " + shp.fule.ToString();
            }
        }
    }
}