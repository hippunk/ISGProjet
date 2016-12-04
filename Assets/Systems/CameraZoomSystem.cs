using UnityEngine;
using FYFY;

public class CameraZoomSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Camera),typeof(Move))); // NOTE : add shake (utlity in onProcess)
	private Family _worldLimitGO = FamilyManager.getFamily(new AllOfComponents(typeof(WorldLimit))); // NOTE : add shake (utlity in onProcess)

	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			//Transform camTransform = go.GetComponent<Transform> ();
			Camera cam = go.GetComponent<Camera> ();
			//Move camMove = go.GetComponent<Move> ();
			Renderer wl = null;

			foreach (GameObject go2 in _worldLimitGO) {
				wl = go2.GetComponent<Renderer> ();
			}


			float vertExtent = cam.orthographicSize;    
			float horzExtent = vertExtent * Screen.width / Screen.height;
			float xsize = wl.bounds.size.x;
			float ysize = wl.bounds.size.y;


            if (Input.GetAxis ("Mouse ScrollWheel") < 0 && ((horzExtent+1)*2 < xsize && (vertExtent+1)*2 < ysize)) {
				Debug.Log ("dezoom");
				cam.orthographicSize = cam.orthographicSize+1;
			}
            if (horzExtent * 2 > xsize || vertExtent * 2 > ysize)
            {
                cam.orthographicSize--;
            }
            if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				//Debug.Log ("zoom");
				cam.orthographicSize = Mathf.Max(cam.orthographicSize-1,1);
				//cam.orthographicSize = Mathf. (cam.orthographicSize-1,6);
			}


		}
	}
}