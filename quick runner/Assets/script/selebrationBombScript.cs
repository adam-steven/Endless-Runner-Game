using UnityEngine;
using System.Collections;

public class selebrationBombScript : MonoBehaviour {

	public Material normal;
	public Material flash;
	public Transform texturedModel;
	private Renderer rend;

	private bool onFlash;

	public float flashTimer;
	private float setFlashTimer;

	public float explodeTimer;
	public GameObject explodedBomb;

	void Start () {
		rend = texturedModel.GetComponent<Renderer>();
		setFlashTimer = flashTimer;
	}
	

	void Update () {

		flashTimer -= Time.deltaTime;
		explodeTimer -= Time.deltaTime;

		if (flashTimer <= 0) {
			if (!onFlash) {
				rend.material = flash;
				onFlash = true;
			} else {
				rend.material = normal;
				onFlash = false;
			}

			flashTimer = setFlashTimer;
		}

		if (explodeTimer <= 0) {
			Instantiate (explodedBomb, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	
	}
}
