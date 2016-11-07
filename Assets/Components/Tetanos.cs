using UnityEngine;
using System.Collections;

public class Tetanos : MonoBehaviour {
    float cpt = 70;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update() {
        if (cpt > 0 && cpt%2 == 0){ 
        transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
         }
        cpt = cpt - 0.5f;

    }
}
