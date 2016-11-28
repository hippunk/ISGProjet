using UnityEngine;
using FYFY;

public class ChangementNiveau : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.

    private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(RandomTarget))); // NOTE : changer components pour traiter tous les enemis
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
            GameObjectManager.loadScene("Tests3");
        }
        
            foreach (GameObject go in _heatGO)
            {
                if (go.GetComponent<Heat>().heat >= 0)
                {
                    Sprite sprite= Resources.Load<Sprite>("gameover");
                    GameObject bg = GameObject.FindGameObjectWithTag("background");
                    bg.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    bg.GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }
        
	}
}