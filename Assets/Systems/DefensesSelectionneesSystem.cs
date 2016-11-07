using UnityEngine;
using FYFY;
//using FYFY_plugins.MouseManager;

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
		Debug.Log ("******Defenses Selected");
		Debug.Log ("---------> Family : " + _controllableGO.Count);
		foreach (GameObject go in _controllableGO) {
			Move mv = go.GetComponent<Move> ();
			Debug.Log ("Dans ma famille...");
			// Si la défense est déjà en chemin
			if (go.GetComponent<Selected> ().en_route ) {
				Vector3 goal = go.GetComponent<Selected> ().goalPosition;
				Debug.Log("Je continue à me déplacer vers " + goal + "!");
				// Si on est arrivé à destination
				if (go.transform.position.Equals (goal)) {
					Debug.Log ("Bien arrivé");
					GameObjectManager.removeComponent<Selected> (go);
					//GameObjectManager.removeComponent<DefensesEnRoute> (go);
				} else {
					go.transform.position = Vector3.MoveTowards (go.transform.position, goal, mv.speed * Time.deltaTime);
				}
			}
			else if (Input.GetMouseButtonDown (1)) {
				Debug.Log ("Bouton droit enfoncé");
				// on recupere la camera relativement a l'objet
				Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
				Debug.Log("Je veux me déplacer de " + go.transform.position+ " vers " + Input.mousePosition + "!");
				//GameObjectManager.addComponent<DefensesEnRoute> (go);
				// on trouve la position relative
				Vector3 goal = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.0f));
				// on garde le meme layer (meme z)
				goal.z = go.transform.position.z;
				Debug.Log("Je vais me déplacer de " + go.transform.position+ " vers " + goal + "!");
				go.transform.position = Vector3.MoveTowards (go.transform.position, goal, mv.speed * Time.deltaTime);
				go.GetComponent<Selected> ().goalPosition = goal;
				go.GetComponent<Selected> ().en_route = true;
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