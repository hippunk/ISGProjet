using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class HeatSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(RandomTarget))); // NOTE : changer components pour traiter tous les enemis
	private Family _heatBarGO = FamilyManager.getFamily(new AllOfComponents(typeof(HeatBar))); // famille pour changer la bar temperature
	private Family _heatGO = FamilyManager.getFamily(new AllOfComponents(typeof(Heat))); // famille pour changer la temperature

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		int nbHostile = _hostileGO.Count;
		foreach (GameObject go in _heatBarGO){
			RectTransform heatTransform = go.GetComponent<RectTransform> ();
			if (heatTransform.sizeDelta.y < 285) {
				heatTransform.sizeDelta = new Vector3 (heatTransform.sizeDelta.x, 35 + 5 * nbHostile);
				foreach (GameObject goT in _heatGO) {
					Text heatText = goT.GetComponent<Text> ();
					heatText.text = (37.0f + 0.1f * nbHostile) + "°C";
				}
			}
		}

	}
}