using UnityEngine;
using FYFY;

public class MacrophageFactory : FSystem
{
    private Family _celluleGO = FamilyManager.getFamily(
            new AllOfComponents(typeof(Cellule)));
	private Family _macroGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Macrophage)));
	private Family _lymphoGO = FamilyManager.getFamily(
		new AnyOfComponents(typeof(Lympho),typeof(LymphoBac),typeof(LymphoVir)));
	private Family _T8GO = FamilyManager.getFamily(
		new AllOfComponents(typeof(T8)));
	
    private float reloadTime = 4f;
    private float reloadProgress = 0f;
    //private bool stopGen = false;
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    protected override void onProcess(int familiesUpdateCount)
	{


	//if (!stopGen) {
		reloadProgress += Time.deltaTime;

		if (reloadProgress >= reloadTime)
		{
			foreach ( GameObject cell in _celluleGO) { 
				GameObject go = null;

				if ( cell.GetComponent<PopComponent> ().popMacro && _macroGO.Count <= 10) {
					go = GameObjectManager.instantiatePrefab ("Macrophage");
					go.transform.position = new Vector3 (cell.transform.position.x + 1f - (Random.value + 2f), cell.transform.position.y + 1f - (Random.value + 2f));
					if (cell.GetComponent<Infecte> ()) {
						go.GetComponent<SpriteRenderer> ().color = Color.green;
						GameObjectManager.addComponent<Infecte> (go);
					}
				}
				if (cell.GetComponent<PopComponent> ().popB && _lymphoGO.Count <= 5) {
					go = GameObjectManager.instantiatePrefab ("Lymphocyte");
					go.transform.position = new Vector3 (cell.transform.position.x + 1f - (Random.value + 2f), cell.transform.position.y + 1f - (Random.value + 2f));
					if (cell.GetComponent<Infecte> ()) {
						go.GetComponent<SpriteRenderer> ().color = Color.green;
						GameObjectManager.addComponent<Infecte> (go);
					}
				}
				if ( cell.GetComponent<PopComponent> ().popT8 && _T8GO.Count <= 3) {
					go = GameObjectManager.instantiatePrefab ("T8");
					go.transform.position = new Vector3 (cell.transform.position.x + 1f - (Random.value + 2f), cell.transform.position.y + 1f - (Random.value + 2f));
					if (cell.GetComponent<Infecte> ()) {
						go.GetComponent<SpriteRenderer> ().color = Color.green;
						GameObjectManager.addComponent<Infecte> (go);
					}
				}


			reloadProgress = 0;

			}
		}
	}
}