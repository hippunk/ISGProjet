using UnityEngine;
using System.Collections;
using FYFY;

public class AnimationSystem : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Life)));

	protected override void onProcess(int familiesUpdateCount){
		foreach (GameObject go in _controllableGO) {
			Color col = go.GetComponent<Renderer> ().material.color;
			//Lorsqu'un organisme meurt, déclenchement d'une animation pour qu'il disparaisse progressivement
			if (go.GetComponent<Life> ().life <= 0 && col.a > 0) {
				col.a -= 0.01f;
				go.GetComponent<Renderer> ().material.color = col;
			}

			//Destruction du gameObject lorsqu'il n'est plus visible
			if (col.a <= 0)
				GameObjectManager.destroyGameObject (go);
		}
	}
}
