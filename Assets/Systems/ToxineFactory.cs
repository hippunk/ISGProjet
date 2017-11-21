using UnityEngine;
using FYFY;

public class ToxineFactory : FSystem {
	private Family _bacGO = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie)));
	private float reloadTime = 5f;
	private float reloadProgress = 0f;
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		reloadProgress += Time.deltaTime;

		Debug.Log ("Tox factory : "+reloadProgress);
		if (reloadProgress >= reloadTime)
		{
			foreach (GameObject go in _bacGO) {
				Debug.Log ("Pop toxines : "+_bacGO);
				//GameObjectManager.instantiatePrefab ("toxine").transform.position = go.transform.position;
				GameObject obj = GameObject.Instantiate ((GameObject)Resources.Load ("toxine"));
				obj.transform.position = go.transform.position;    
				GameObjectManager.bind (obj);


			}
			reloadProgress = 0;
		}

	}
}