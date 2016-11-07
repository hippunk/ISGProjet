using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class MoveArrows : MonoBehaviour {
	public float speed = 2.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = Vector3.zero;
		
		if (Input.GetKey(KeyCode.LeftArrow) == true) {
			movement += Vector3.left;
		}
		if (Input.GetKey(KeyCode.RightArrow) == true) {
			movement += Vector3.right;
		}
		if (Input.GetKey(KeyCode.UpArrow) == true) {
			movement += Vector3.up;
		}
		if (Input.GetKey(KeyCode.DownArrow) == true) {
			movement += Vector3.down;
		}
		transform.position += movement * speed * Time.deltaTime;
	}
}
