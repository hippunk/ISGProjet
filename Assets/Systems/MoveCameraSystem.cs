using UnityEngine;
using FYFY;

public class MoveCameraSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Camera),typeof(Move))); // NOTE : add shake (utlity in onProcess)
	private Family _worldLimitGO = FamilyManager.getFamily(new AllOfComponents(typeof(WorldLimit))); // NOTE : add shake (utlity in onProcess)
		// Update is called once per frame

	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Transform camTransform = go.GetComponent<Transform> ();
			Camera cam =  go.GetComponent<Camera> ();
			Move camMove = go.GetComponent<Move> ();
			Renderer wl = null;

			foreach(GameObject go2 in _worldLimitGO) {
				wl = go2.GetComponent<Renderer> ();
			}

			float vertExtent = cam.orthographicSize;    
			float horzExtent = vertExtent * Screen.width / Screen.height;

			float Olim = wl.transform.position.x - wl.bounds.size.x / 2  + 0.01f;
			float Elim = wl.transform.position.x + wl.bounds.size.x / 2 - 0.01f;
			float Slim = wl.transform.position.y - wl.bounds.size.y / 2 + 0.01f;
			float Nlim = wl.transform.position.y + wl.bounds.size.y / 2 - 0.01f;

			float COlim = cam.transform.position.x - horzExtent ;
			float CElim = cam.transform.position.x + horzExtent ;
			float CSlim = cam.transform.position.y - vertExtent ;
			float CNlim = cam.transform.position.y + vertExtent ;


			if(Input.GetKey(KeyCode.UpArrow ) && CNlim < Nlim){
				camTransform.Translate(Vector3.up * Time.deltaTime * camMove.speed);    
				}
			if(Input.GetKey(KeyCode.DownArrow) && CSlim > Slim){
				camTransform.Translate(Vector3.down * Time.deltaTime* camMove.speed);    
				}
			if(Input.GetKey(KeyCode.RightArrow) && CElim < Elim){
				camTransform.Translate(Vector3.right * Time.deltaTime* camMove.speed);    
				}
			if(Input.GetKey(KeyCode.LeftArrow ) && COlim > Olim){
				camTransform.Translate(Vector3.left * Time.deltaTime* camMove.speed);    
				}
				


			//Debug.Log ("pos :");
			//Debug.Log (Olim + cam.pixelWidth / 2);
			//Debug.Log ("Debug mouse position");
			//Debug.Log(Input.mousePosition);

			int Xgap10 = (int)(cam.pixelHeight * 0.1);
			int Ygap10 = (int)(cam.pixelWidth * 0.1);

			int In = cam.pixelHeight - Xgap10;
			int Is = Xgap10;
			int Io = Ygap10;
			int Ie = cam.pixelWidth - Ygap10;
			int On = cam.pixelHeight;
			int Os = 0;
			int Oo = 0;
			int Oe = cam.pixelWidth;

			if(Input.mousePosition.x >= Oo && Input.mousePosition.x < Io && COlim > Olim){ //Parie Ouest
				camTransform.Translate (Vector3.left * Time.deltaTime * camMove.speed* ((System.Math.Abs(Input.mousePosition.x - Io)) / Ygap10));   //Dernier chiffre facteur de proportionalité entre 0 et 1 de la speed
				//Debug.Log("Fact prop O");
				//Debug.Log(((System.Math.Abs(Input.mousePosition.x - Io)) / Ygap10));
			}
			if(Input.mousePosition.x > Ie && Input.mousePosition.x <= Oe && CElim < Elim){ //Partie Est
				camTransform.Translate (Vector3.right * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.x - Ie)) / Ygap10));   
				//Debug.Log("Fact prop E");
				//Debug.Log(((System.Math.Abs(Input.mousePosition.x - Ie)) / Ygap10));
			}
			if(Input.mousePosition.y >= Os && Input.mousePosition.y < Is && CSlim > Slim){ //Partie Sud 
				camTransform.Translate (Vector3.down * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.y - Is)) / Xgap10)); 
				//Debug.Log("Fact prop S");
				//Debug.Log(((System.Math.Abs(Input.mousePosition.y - Is)) / Xgap10));
			}
			if(Input.mousePosition.y > In && Input.mousePosition.y <= On && CNlim < Nlim){ //Partie Nord
				camTransform.Translate (Vector3.up * Time.deltaTime * camMove.speed * ((System.Math.Abs(Input.mousePosition.y - In)) / Xgap10)); 
				//Debug.Log("Fact prop N");
				//Debug.Log(((System.Math.Abs(Input.mousePosition.y - In)) / Xgap10));
			}

			//Réalignement en cas de changement de taille de map
			if (COlim < Olim)
				cam.transform.position = new Vector3 (Olim + horzExtent, cam.transform.position.y, -10);
			if (CElim > Elim)
				cam.transform.position = new Vector3 (Elim - horzExtent, cam.transform.position.y, -10);
			if (CNlim > Nlim)
				cam.transform.position = new Vector3 (cam.transform.position.x,Nlim - vertExtent, -10);
			if (CSlim < Slim)
				cam.transform.position = new Vector3 (cam.transform.position.x,Slim + vertExtent, -10);

		}

	}
}