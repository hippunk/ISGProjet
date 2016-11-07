using UnityEngine;
using FYFY;

public class MoveCamera : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Camera),typeof(Move))); // NOTE : add shake (utlity in onProcess)
		// Update is called once per frame

	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Transform camTransform = go.GetComponent<Transform> ();
			Camera cam =  go.GetComponent<Camera> ();
			Move camMove = go.GetComponent<Move> ();

			if(Input.GetKey(KeyCode.UpArrow)){
				camTransform.Translate(Vector3.up * Time.deltaTime * camMove.speed);    
				}
			if(Input.GetKey(KeyCode.DownArrow)){
				camTransform.Translate(Vector3.down * Time.deltaTime* camMove.speed);    
				}
			if(Input.GetKey(KeyCode.RightArrow)){
				camTransform.Translate(Vector3.right * Time.deltaTime* camMove.speed);    
				}
			if(Input.GetKey(KeyCode.LeftArrow)){
				camTransform.Translate(Vector3.left * Time.deltaTime* camMove.speed);    
				}


			Debug.Log ("Debug mouse position");
			Debug.Log(Input.mousePosition);

			int Xgap10 = (int)(cam.pixelHeight * 0.2);
			int Ygap10 = (int)(cam.pixelWidth * 0.2);

			int In = cam.pixelHeight - Xgap10;
			int Is = Xgap10;
			int Io = Ygap10;
			int Ie = cam.pixelWidth - Ygap10;
			int On = cam.pixelHeight;
			int Os = 0;
			int Oo = 0;
			int Oe = cam.pixelWidth;

			if(Input.mousePosition.x >= Oo && Input.mousePosition.x < Io){ //Parie Ouest
				camTransform.Translate (Vector3.left * Time.deltaTime * camMove.speed* ((System.Math.Abs(Input.mousePosition.x - Io)) / Ygap10));   //Dernier chiffre facteur de proportionalité entre 0 et 1 de la speed
				Debug.Log("Fact prop O");
				Debug.Log(((System.Math.Abs(Input.mousePosition.x - Io)) / Ygap10));
			}
			if(Input.mousePosition.x > Ie && Input.mousePosition.x <= Oe){ //Partie Est
				camTransform.Translate (Vector3.right * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.x - Ie)) / Ygap10));   
				Debug.Log("Fact prop E");
				Debug.Log(((System.Math.Abs(Input.mousePosition.x - Ie)) / Ygap10));
			}
			if(Input.mousePosition.y >= Os && Input.mousePosition.y < Is){ //Partie Sud 
				camTransform.Translate (Vector3.down * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.y - Is)) / Xgap10)); 
				Debug.Log("Fact prop S");
				Debug.Log(((System.Math.Abs(Input.mousePosition.y - Is)) / Xgap10));
			}
			if(Input.mousePosition.y > In && Input.mousePosition.y <= On){ //Partie Nord
				camTransform.Translate (Vector3.up * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.y - In)) / Xgap10)); 
				Debug.Log("Fact prop N");
				Debug.Log(((System.Math.Abs(Input.mousePosition.y - In)) / Xgap10));
			}



		}

	}
}