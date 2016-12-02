using UnityEngine;
using FYFY;

public class MacrophageFactory : FSystem
{
    private Family _celluleGO = FamilyManager.getFamily(
            new AllOfComponents(typeof(Cellule)));
    private float reloadTime = 2f;
    private float reloadProgress = 0f;
    //private bool stopGen = false;
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    protected override void onPause(int currentFrame)
    {
//        Debug.Log("En Pause ! ");
    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame)
    {
       // GameObject go = GameObjectManager.instantiatePrefab("Macrophage");
        this.Pause = false;
        reloadProgress = 0;
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {

        Family rt = FamilyManager.getFamily(new AllOfComponents(typeof(Defenses)));
        if (rt.Count == 5)
            this.Pause = true;

        foreach ( GameObject cell in _celluleGO) { 
        //if (!stopGen) {
	        reloadProgress += Time.deltaTime;

			if (reloadProgress >= reloadTime)
			{
				GameObject go = null;
				int rand = Random.Range (1, 4);
				if(rand == 1)
			    	go = GameObjectManager.instantiatePrefab("Macrophage");
				if(rand == 2)
					go = GameObjectManager.instantiatePrefab("Lymphocyte");
				if(rand == 3)
					go = GameObjectManager.instantiatePrefab("T8");
				
			    go.transform.position = new Vector3 (cell.transform.position.x  + 1f - ( Random.value + 2f), cell.transform.position.y + 1f - (Random.value + 2f));
			    reloadProgress = 0;
			    
			}
		}
    }
}