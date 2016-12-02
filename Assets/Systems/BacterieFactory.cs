using UnityEngine;
using FYFY;

public class BacterieFactory : FSystem {

	private float reloadTime = 1f;
	private float reloadProgress = 0f;
	//private bool stopGen = false;
    private int cpt = 0;
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
		Debug.Log ("En Pause ! ");
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
		/*GameObject go = */GameObjectManager.instantiatePrefab ("bacterie_triyeux");
		this.Pause = false;
		reloadProgress = 0;
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		Family rt = FamilyManager.getFamily (new AllOfComponents (typeof(RandomTarget)), new AllOfComponents(typeof (Bacterie)));
		if (rt.Count == 0)
			this.Pause = true;

		//if (!stopGen) {
			reloadProgress += Time.deltaTime;

			if (reloadProgress >= reloadTime && cpt < 30) {
				GameObject go = GameObjectManager.instantiatePrefab ("bacterie_triyeux");
				GameObject background = GameObject.FindGameObjectWithTag ("background");
				go.transform.position = background.transform.position; //new Vector3 ((Random.value - 0.5f) * 7,(Random.value - 0.5f) * 5.2f);
				reloadProgress = 0;
            cpt++;
			}
		//}
	}
}