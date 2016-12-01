using UnityEngine;
using FYFY;



public class AnticorpsFactory : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _lymphoBacGO = FamilyManager.getFamily(new AllOfComponents(typeof(LymphoBac)));
    private Family _lymphoVirGO = FamilyManager.getFamily(new AllOfComponents(typeof(LymphoVir)));
    private Family _hostileVirus = FamilyManager.getFamily(new AllOfComponents(typeof(Virus)));
    private Family _hostileBacterie = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie)));
    private Family _antiVirus = FamilyManager.getFamily(new AllOfComponents(typeof(AnticorpVirus)));
    private Family _antiBacterie = FamilyManager.getFamily(new AllOfComponents(typeof(AnticorpBacterie)));
    private float reloadTime = 1f;
    private float reloadProgress = 0f;

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount) {

        //if (!stopGen) {
        reloadProgress += Time.deltaTime;
        int cptBac = 0;
        int cptVir = 0;

        if (reloadProgress >= reloadTime)
        {
            foreach (GameObject go in _lymphoBacGO) {
                if (_antiBacterie.Count < _hostileBacterie.Count * 3)
                   
                    GameObjectManager.instantiatePrefab("anticorp-bacterie").transform.position = go.transform.position;
            }
            foreach (GameObject go in _lymphoVirGO)
            {
                if (_antiVirus.Count < _hostileVirus.Count * 3)
                    GameObjectManager.instantiatePrefab("anticorp-virus").transform.position = go.transform.position;
            }
            reloadProgress = 0;
        }
        //}

    }
}