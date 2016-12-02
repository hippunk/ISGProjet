using UnityEngine;
using FYFY;

public class ToxineFactory : FSystem {
	private Family _bacGO = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie)));
	private float reloadTime = 5f;
	private float reloadProgress = 0f;
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		reloadProgress += Time.deltaTime;


		if (reloadProgress >= reloadTime)
		{
			foreach (GameObject go in _bacGO) {

				GameObjectManager.instantiatePrefab ("toxine").transform.position = go.transform.position;

				reloadProgress = 0;
			}
		}
	}
}