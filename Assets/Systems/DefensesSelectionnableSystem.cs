using UnityEngine;
using FYFY;
using FYFY_plugins.MouseManager;

public class DefensesSelectionnableSystem : FSystem {
	// on récupere les elt defensifs qui sont selectionnables mais pas encore sélectionnées
	// et qui peuvent se déplacer et ont été focused par la souris du joueur
	private Family _controllableGO = FamilyManager.getFamily (
		new AllOfComponents (typeof(Move)),
		new NoneOfComponents (typeof(RandomTarget)),
		new AllOfComponents (typeof(MouseOver)),
		new AllOfComponents (typeof(Defenses)),
		new AllOfComponents (typeof(Selectionnable)),
		new NoneOfComponents(typeof(Selected)));

	/*private Family _updatableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move)),
		new NoneOfComponents(typeof(RandomTarget)),
		new AllOfComponents(typeof(Defenses)),
		new AllOfComponents(typeof(Selected)));
	*/
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
		// clic gauche : selection de l'objet defensif
		// si l'utilisateur demande à en selectionner plusieurs (enfonce la touche ctrl)
		// si l'utilisateur souhaite sélectionner une défense
		if (Input.GetMouseButtonDown (0) ) { //&& Input.GetKeyDown(KeyCode.RightControl)) {
			// on sélectionne tous les games objects focused (il n'y en a tjr qu'un à la fois)
			foreach (GameObject go in _controllableGO) {
				// On sélectionne l'objet
				GameObjectManager.addComponent<Selected>(go);
				go.GetComponent<Selected> ().can_change_goal = true;
				/*
				// clic gauche : déselection des gameobjects sur place
				if (go.GetComponent<Selected>() != null) {
					GameObjectManager.removeComponent<Selected> (go);
				} else {
					GameObjectManager.addComponent<Selected>(go);
				}
				*/
				/*Transform tr = go.GetComponent<Transform> ();
				Move mv = go.GetComponent<Move> ();

				Vector3 movement = Vector3.zero;

				if (Input.GetKey (KeyCode.LeftArrow) == true) {
					movement += Vector3.left;
				}
				if (Input.GetKey (KeyCode.RightArrow) == true) {
					movement += Vector3.right;
				}
				if (Input.GetKey (KeyCode.UpArrow) == true) {
					movement += Vector3.up;
				} 
				if (Input.GetKey (KeyCode.DownArrow) == true) {
					movement += Vector3.down;
				}

				tr.position += movement * mv.speed * Time.deltaTime;
				*/
			}
		}
		// au clique droit le joueur peut déplacer un de ses bonshommes
			// si on a deja selectionné un gameobject, c'est le deuxieme clic (choix du placement)
			// sinon on sélectionne le gameobject, c'est le premier clic

	}

}