using UnityEngine;
using FYFY;

public class RandomMovingSystem : FSystem {

	private Family _randomMovingGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move),typeof(RandomTarget)));

	public RandomMovingSystem(){
		foreach (GameObject go in _randomMovingGO){
			onGOEnter(go);
		}
		_randomMovingGO.addEntryCallback(onGOEnter);

	}
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	private void onGOEnter(GameObject go) {
		Transform tr = go.GetComponent<Transform> ();
		RandomTarget rt = go.GetComponent<RandomTarget> ();
		rt.target = tr.position;
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach(GameObject go in _randomMovingGO){
			Transform tr = go.GetComponent<Transform> ();
			RandomTarget rt = go.GetComponent<RandomTarget> ();
			Move mv = go.GetComponent<Move> ();
			Bounds bd = GameObject.FindGameObjectWithTag ("background").GetComponent<Renderer> ().bounds;
			if ( (rt.target[0] < bd.max.x && rt.target[0] > bd.min.x && rt.target[1] < bd.max.y && rt.target[1] > bd.min.y)
				&& ! (rt.target.Equals(tr.position)) ) {
				tr.position = Vector3.MoveTowards (tr.position, rt.target, mv.speed * Time.deltaTime);
			} else {
				Vector2 backPosition = GameObject.FindGameObjectWithTag ("background").transform.position;
				rt.target = new Vector2 ((Random.Range(bd.min.x, bd.max.x)), (Random.Range(bd.min.y,bd.max.y))); //(Random.Range(backPosition[0] - 0.5f, backPosition[0] + 0.5f)) * 7, (Random.Range(backPosition[1] - 0.5f, backPosition[1] + 0.5f)) * 7);
			} 
			/*
			Vector2 backPosition = GameObject.FindGameObjectWithTag ("background").transform.position;
			rt.target = new Vector2 ((Random.Range(bd.min.x, bd.max.x)), (Random.Range(bd.min.y,bd.max.y)));
			tr.position = Vector3.MoveTowards (tr.position, rt.target, mv.speed * Time.deltaTime);
			*/
		}
	}
}