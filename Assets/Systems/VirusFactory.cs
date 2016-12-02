using UnityEngine;
using FYFY;

public class VirusFactory : FSystem
{
    private Family _infecteGO = FamilyManager.getFamily(
    new AllOfComponents(typeof(Infecte)));

    //private float reloadTime = 1f;
    //private float reloadProgress = 0f;
    //private bool stopGen = false;


    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    protected override void onPause(int currentFrame)
    {
        Debug.Log("En Pause ! ");
    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame)
    {

    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {

        //if (!stopGen) {

        foreach (GameObject i in _infecteGO)
        {

                int tmp = i.GetComponent<Infecte>().tempsavantmort - 1;
                i.GetComponent<Infecte>().tempsavantmort = tmp;
                if (i.GetComponent<Infecte>().tempsavantmort <= 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        GameObject go = GameObjectManager.instantiatePrefab("virus");
                        go.transform.position =new Vector3 (i.transform.position.x - Random.value * 2 + 1, i.transform.position.y - Random.value * 2 + 1); //new Vector3 ((Random.value - 0.5f) * 7,(Random.value - 0.5f) * 5.2f);
                    }
					GameObjectManager.removeComponent<Infecte>(i);
                    i.GetComponent<Life>().life = 0;
					//GameObjectManager.destroyGameObject(i);
				}
				
        }

       
        //}
    }
}