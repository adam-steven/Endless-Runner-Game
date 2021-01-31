using UnityEngine;
using System.Collections;

public class lightsMoveScript : MonoBehaviour {
//	
//	private Transform spawner;
//	private spawnerScript ss;
//
//	private float moveTimer;
//	private bool noLights;
//
//	public float startingXPosition;
//	public float startingYPosition;
//	public float startingZPosition;
//
//	public bool LeftLight;
//
//	void Start () {
//		spawner = GameObject.FindWithTag ("spawner").transform;
//		ss = spawner.GetComponent<spawnerScript>();
//	}
//
//	void Update () {
//
//		if(GameObject.FindGameObjectWithTag("Player") && PlayerPrefs.GetInt("TTpause") == 0)
//		{
//			if (LeftLight) 
//			{
//				if (ss.leftLightGoing && moveTimer <= 0 && noLights)
//				{
//					moveTimer = 5;
//				}
//			} 
//			else 
//			{
//				if (ss.rightLightGoing && moveTimer <= 0 && noLights)
//				{
//					moveTimer = 5;
//				}
//			}
//
//			if (moveTimer > 0 && noLights) 
//			{
//				transform.position = new Vector3 (startingXPosition, startingYPosition, startingZPosition);
//				noLights = false;
//			}
//
//			if (moveTimer > 0 && !noLights) 
//			{
//				if (LeftLight) 
//				{
//					transform.Translate (Vector3.right * (ss.speed + ss.speedIncrease) * Time.deltaTime);
//				}
//				else 
//				{
//					transform.Translate (Vector3.left * (ss.speed + ss.speedIncrease) * Time.deltaTime);
//				}
//
//				moveTimer -= Time.deltaTime;
//			}
//
//			if(moveTimer <= 0 && !noLights)
//			{
//				transform.position = new Vector3 (10000, 10000, 10000);
//				noLights = true;
//
//				if (LeftLight) 
//				{
//					ss.leftLightGoing = false;
//				} 
//				else 
//				{
//					ss.rightLightGoing = false;
//				}
//			}
//		}
//	}
}
