using UnityEngine;
using FYFY;
using FYFY_plugins.MouseManager;

public class AfficheInfos : FSystem {

	private Family _entitesGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(MouseOver))); // NOTE : changer components pour traiter tous les enemis

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
		foreach (GameObject go in _entitesGO) {
			Debug.Log ("Afficher sa vie, nom, ...");
		}
	}
}