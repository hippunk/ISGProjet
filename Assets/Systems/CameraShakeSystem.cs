using UnityEngine;
using FYFY;

public class CameraShakeSystem : FSystem
{


	private Family _controllableGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Camera))); // NOTE : add shake (utlity in onProcess)
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.

	Vector3 originalPos;

	protected override void onPause (int currentFrame)
	{
		Debug.Log ("onPause");
	}

	protected override void onResume(int currentFrame){
		foreach (GameObject go in _controllableGO) {
			Transform camTransform = go.GetComponent<Transform> ();

			originalPos = camTransform.localPosition;

		}
	}
	protected override void onProcess(int familiesUpdateCount) {
		Debug.Log ("onProcess");
		foreach (GameObject go in _controllableGO) {
			Transform camTransform = go.GetComponent<Transform> ();
			Shake sh = go.GetComponent<Shake> ();



			if (sh.shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * sh.shakeAmount;

				sh.shakeDuration -= Time.deltaTime * sh.decreaseFactor;
			}
			else
			{
				sh.shakeDuration = 0f;
				camTransform.localPosition = originalPos;
				this.onPause(0);
			}
		}
	}
}