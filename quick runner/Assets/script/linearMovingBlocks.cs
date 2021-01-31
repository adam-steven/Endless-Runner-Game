using UnityEngine;


public class linearMovingBlocks : MonoBehaviour {

    public float speed;

	void Start () {
	
	}
	
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
