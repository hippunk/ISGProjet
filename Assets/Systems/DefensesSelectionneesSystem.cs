using UnityEngine;
using FYFY;
using FYFY_plugins.MouseManager;

// Pour toutes les défenses qui ont été sélectionnées
public class DefensesSelectionneesSystem : FSystem {
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Selectionnable)));
	private Family _cameraGO = FamilyManager.getFamily(new AllOfComponents(typeof(Camera))); // NOTE : add shake (utlity in onProcess)

	protected override void onProcess(int familiesUpdateCount) {
		Camera cam = null;
		foreach (GameObject goi in _cameraGO)
			cam = goi.GetComponent<Camera>();
		
		foreach (GameObject go in _controllableGO) {

			if (Input.GetMouseButtonDown (1)) {
	

				if (go.GetComponent<Selected> ()) {
					go.GetComponent<Selectionnable> ().goalPosition = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
					go.GetComponent<Selectionnable> ().goalPosition.z = 0;
				}

			}

			if(go.GetComponent<Selectionnable>().goalPosition != Vector3.zero)
				go.transform.position = Vector3.MoveTowards (go.transform.position, go.GetComponent<Selectionnable>().goalPosition, go.GetComponent<Move>().speed * Time.deltaTime);
		}
	}

}