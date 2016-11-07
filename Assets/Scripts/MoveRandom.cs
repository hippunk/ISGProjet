using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class MoveRandom : MonoBehaviour {
	public float speed = 2.0f;

	private Transform target;
	private Transform transform;
	
	// Use this for initialization
	void Start () {
		transform = target = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		float xpos = Random.Range (-5f,5f);
		float ypos = Random.Range (-5f,5f);
		target.position = new Vector3(xpos, ypos, 0);
		Debug.Log ("Nouvelle position" + target.position);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		
		//float card = rnd.NextDouble() * 5;
		//float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

}
