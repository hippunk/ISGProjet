using UnityEngine;
using FYFY;
using FYFY_plugins.MouseManager;

// Pour toutes les défenses qui ont été sélectionnées
public class DefensesSelectionneesSystem : FSystem {
	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Move)),
		new NoneOfComponents(typeof(RandomTarget)),
		new AllOfComponents(typeof(Defenses)),
		new AllOfComponents(typeof(Selected)));
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
		// clic droit : choix de l'objet defensif
		//Debug.Log ("******Defenses Selected");
		//Debug.Log ("---------> Family : " + _controllableGO.Count);
		foreach (GameObject go in _controllableGO) {
			Move mv = go.GetComponent<Move> ();
			//Debug.Log ("Dans ma famille...");
			Selected selcomp = go.GetComponent<Selected>();
			if (Input.GetMouseButtonDown (1) && selcomp.can_change_goal) {
				//Debug.Log ("Bouton droit enfoncé");
				// on recupere la camera relativement a l'objet pour avoir une position relative au joueur
				Camera camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
				//Debug.Log ("Je veux me déplacer de " + go.transform.position + " vers " + Input.mousePosition + "!");
				// on trouve la position relative
				Vector3 goal = camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
				// on garde le meme layer (meme z) pour que la défense reste SUR le background
				goal.z = go.transform.position.z;
				//Debug.Log ("Je vais me déplacer de " + go.transform.position + " vers " + goal + "!");
				go.transform.position = Vector3.MoveTowards (go.transform.position, goal, mv.speed * Time.deltaTime);
				go.GetComponent<Selected> ().goalPosition = goal;
				go.GetComponent<Selected> ().en_route = true;
				// mais on peut toujours changer de destination finale (par précaution)
				go.GetComponent<Selected> ().can_change_goal = true;
			}
			// si l'utilisateur a cliqué sur clic Gauche et sur CTRL Gauche ou CTRL droit
			// Pour déselectionner la défense en cours et laisser les autres pour après les deplacer au meme clic
			else if (Input.GetMouseButtonDown (0) && Input.GetKey (KeyCode.LeftControl)) {
				// on déselectionne l'entité qui avait deja été selectionnée et qui est survolée par la souris
				if (go.GetComponent<MouseOver> ()) {
					GameObjectManager.removeComponent<Selected> (go);
                    Sprite tmp = go.GetComponent<Selectionnable>().sprite;

                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<SpriteRenderer>().sprite;
                    go.GetComponent<SpriteRenderer>().sprite = tmp;
                }
			}
			// pour ne sélectionner qu'une défense à la fois (ici on desactive les precedentes selections)
			else if (Input.GetMouseButtonDown (0)) {
				// On déselectionne toutes les entités précédemment sélectionnées 
				// et on garde juste l'entité courante donc :
				// si l'entité n'a pas la souris au-dessus
				if (! go.GetComponent<MouseOver> ()) {
                    Sprite tmp = go.GetComponent<Selectionnable>().sprite;

                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<SpriteRenderer>().sprite;
                    go.GetComponent<SpriteRenderer>().sprite = tmp;
                    // on recupere le composant selected de l'entité
                    // si l'entité est en route
                    if (selcomp.en_route) {
						// on declare que l'entité ne peut rechanger de destination
						selcomp.can_change_goal = false;
					} else { // sinon
						// on supprime le composant Selected du gameobject
						GameObjectManager.removeComponent<Selected> (go);

					}
				}
			}

			// Si la défense est en chemin, on avance vers la destination quelle quelle  soit
			if (go.GetComponent<Selected> ().en_route) {
				// on continue de se déplacer
				Vector3 goal = selcomp.goalPosition;
				//Debug.Log ("Je continue à me déplacer vers " + goal + "!");
				// Si on est arrivé à destination
				if (go.transform.position.Equals (goal)) {
					//Debug.Log ("Bien arrivé");
					// si l'entité a été déselectionnée par le joueur
					if (selcomp.can_change_goal == false) {
						// le composant selected lui est supprimé
						GameObjectManager.removeComponent<Selected> (go);
					} else {
						// L'entité reste sélectionnée mais n'est plus en route et peut changer de destination
						selcomp.en_route = false;
						selcomp.can_change_goal = true;
					}
				} else {
					go.transform.position = Vector3.MoveTowards (go.transform.position, goal, mv.speed * Time.deltaTime);
				}
			}
		}
		// au clique droit le joueur peut déplacer un de ses bonshommes
			// si on a deja selectionné un gameobject, c'est le deuxieme clic (choix du placement)
			// sinon on sélectionne le gameobject, c'est le premier clic

	}

}