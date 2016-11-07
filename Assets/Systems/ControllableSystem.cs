using UnityEngine;
using FYFY;
using FYFY_plugins.MouseManager;

public class ControllableSystem : FSystem {
	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move)),
		new NoneOfComponents(typeof(RandomTarget)),
		new AllOfComponents(typeof(MouseOver)),
		new AllOfComponents(typeof(Defenses)));
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
		if (Input.GetMouseButtonDown (1)) {
			foreach (GameObject go in _controllableGO) {
				Selected goSelect = go.AddComponent(typeof(Selected)) as Selected;
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