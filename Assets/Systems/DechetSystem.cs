using UnityEngine;
using FYFY;

public class DechetSystem : FSystem {
	private Family _controllableGO = FamilyManager.getFamily (
		new AllOfComponents (typeof(Dechet)),
		new AllOfComponents (typeof(Life)));

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			float life = go.GetComponent<Life> ().life;
			life -= Time.deltaTime;
			go.GetComponent<Life> ().life = life;
		}
	}
}