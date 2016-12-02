using UnityEngine;
using FYFY;

public class ChangementNiveau6 : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	//private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie))); // NOTE : changer components pour traiter tous les enemis
	private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(Virus))); // NOTE : changer components pour traiter tous les enemis
	private Family _heatGO = FamilyManager.getFamily(new AllOfComponents(typeof(Heat))); // famille pour changer la temperature

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		int nbHostile = _hostileGO.Count;

		if (nbHostile == 0) {
			GameObjectManager.loadScene("MenuDemarrer");
		}

		foreach (GameObject go in _heatGO)
		{
			if (go.GetComponent<Heat>().heat >= 42 )
			{
				GameObjectManager.loadScene("GameOver");
			}
		}

	}
}