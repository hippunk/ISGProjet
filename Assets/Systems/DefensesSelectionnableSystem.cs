using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class DefensesSelectionnableSystem : FSystem {
	// on récupere les elt defensifs qui sont selectionnables mais pas encore sélectionnées
	// et qui peuvent se déplacer et ont été focused par la souris du joueur
	private Family _controllableGO = FamilyManager.getFamily (
		new AllOfComponents (typeof(Selectionnable)));



	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		// clic gauche : selection de l'objet defensif
		// si l'utilisateur demande à en selectionner plusieurs (enfonce la touche ctrl)
		// si l'utilisateur souhaite sélectionner une défense
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetMouseButtonDown (0)) { 
			foreach (GameObject go in _controllableGO) {
				// On sélectionne l'objet
				if (go.GetComponent<PointerOver> () != null && go.GetComponent<Selected>() == null) {
					Debug.Log ("CTRL selection");
					GameObjectManager.addComponent<Selected>(go);
					Sprite tmp = go.GetComponent<Selectionnable>().sprite;
					go.GetComponent<Selectionnable>().sprite = go.GetComponent<SpriteRenderer>().sprite;
					go.GetComponent<SpriteRenderer>().sprite = tmp;
				}
				else if(go.GetComponent<PointerOver> () != null && go.GetComponent<Selected>() != null){
					Debug.Log ("CTRL deselection");
					GameObjectManager.removeComponent<Selected>(go);
					Sprite tmp = go.GetComponent<Selectionnable>().sprite;
					go.GetComponent<Selectionnable>().sprite = go.GetComponent<SpriteRenderer>().sprite;
					go.GetComponent<SpriteRenderer>().sprite = tmp;
				}

			}
		}
		else if (Input.GetMouseButtonDown (0) ) { //&& Input.GetKeyDown(KeyCode.RightControl)) {
			// on sélectionne tous les games objects focused (il n'y en a tjr qu'un à la fois)
			foreach (GameObject go in _controllableGO) {
				// On sélectionne l'objet
				if (go.GetComponent<PointerOver> () != null) {
					Debug.Log ("selection");
					if (go.GetComponent<Selected> () == null) {
						GameObjectManager.addComponent<Selected> (go);
						Sprite tmp = go.GetComponent<Selectionnable> ().sprite;
						go.GetComponent<Selectionnable> ().sprite = go.GetComponent<SpriteRenderer> ().sprite;
						go.GetComponent<SpriteRenderer> ().sprite = tmp;
					}
				}
				else if(go.GetComponent<Selected>() != null){
					Debug.Log ("Deselection");
					GameObjectManager.removeComponent<Selected>(go);
					Sprite tmp = go.GetComponent<Selectionnable>().sprite;
					go.GetComponent<Selectionnable>().sprite = go.GetComponent<SpriteRenderer>().sprite;
					go.GetComponent<SpriteRenderer>().sprite = tmp;
				}

			}

		}

	}

}