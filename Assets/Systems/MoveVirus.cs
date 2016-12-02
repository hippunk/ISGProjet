using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class MoveVirus : FSystem
{
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(Virus)));
	private Family _infectGO = FamilyManager.getFamily(new  NoneOfComponents(typeof(Infecte)) , new AnyOfComponents(typeof(Infection)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _hostileGO)
        {
            //Calcul du plus proche :
            float closestDistance = Mathf.Infinity;
            GameObject closest = null;
            Vector3 curPos = go.transform.position;
            foreach (GameObject goi in _infectGO)
            {
                
                    Vector3 directionToTarget = goi.transform.position - curPos;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistance)
                    {
                        closestDistance = dSqrToTarget;
                        closest = goi;
                    }
            }
			//En sortie de boucle closest est le gameObject de l'ennemi le plus proche.
			if (closest != null)
				go.transform.position = Vector3.MoveTowards(curPos, closest.transform.position, Time.deltaTime * go.GetComponent<Move>().speed);
        }
        
    }
}