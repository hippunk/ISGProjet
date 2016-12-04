using UnityEngine;
using FYFY;

public class ChangementNiveau7 : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _defenseGO = FamilyManager.getFamily(new AllOfComponents(typeof(Defenses)), new NoneOfComponents(typeof(Infecte))); // NOTE : changer components pour traiter tous les enemis
	private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(Virus))); // NOTE : changer components pour traiter tous les enemis
	private Family _macroGO = FamilyManager.getFamily(new AllOfComponents(typeof(Macrophage))); // NOTE : changer components pour traiter tous les enemis
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
			//GameObjectManager.loadScene("SelectionNiveau");
            GameObject.Find("GuiManager").GetComponent<GuiManager>().victoire();
        }

		foreach (GameObject go in _heatGO)
		{
			if (go.GetComponent<Heat>().heat >= 42)
			{
                GameObject.Find("GuiManager").GetComponent<GuiManager>().defaite();
                //GameObjectManager.loadScene("GameOver");
			}
		}

		if (_defenseGO.Count == 0)
            GameObject.Find("GuiManager").GetComponent<GuiManager>().defaite();
        //GameObjectManager.loadScene("GameOver");
		if (_macroGO.Count == 0 && nbHostile > 0)
            GameObject.Find("GuiManager").GetComponent<GuiManager>().defaite();
        //GameObjectManager.loadScene("GameOver");
		


	}

}