using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class HeatSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _hostileGO = FamilyManager.getFamily(new AnyOfComponents(typeof(Bacterie),typeof(Virus))); // NOTE : changer components pour traiter tous les enemis
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
			if (heatTransform.sizeDelta.y <= 285) {
				heatTransform.sizeDelta = new Vector3 (heatTransform.sizeDelta.x, Mathf.Min(35f + 5f * nbHostile,285f));
				foreach (GameObject goT in _heatGO) {
					Text heatText = goT.GetComponent<Text> ();
					Heat heat = goT.GetComponent<Heat> ();
					heatText.text = Mathf.Min(37.0f + 0.1f * nbHostile, 42.0f) + "°C";
					heat.heat = Mathf.Min(37.0f + 0.1f * nbHostile,42.0f);
				}
			}
		}

	}
}