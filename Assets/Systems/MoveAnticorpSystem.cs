using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class MoveAnticorpSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _hostileGO = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie),typeof(Aglutine)));
    private Family _anticorpGO = FamilyManager.getFamily(new AllOfComponents(typeof(AnticorpBacterie), typeof(Move)));
    private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(AnticorpBacterie)));

    private Family _hostileVirusGO = FamilyManager.getFamily(new AllOfComponents(typeof(Virus), typeof(Aglutine)));
    private Family _anticorpVirusGO = FamilyManager.getFamily(new AllOfComponents(typeof(AnticorpVirus), typeof(Move)));
    private Family _triggeredAVGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(AnticorpVirus)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in _anticorpGO)
        {
            //Calcul du plus proche :
            float closestDistance = Mathf.Infinity;
            GameObject closest = null;
            Vector3 curPos = go.transform.position;
            foreach (GameObject goi in _hostileGO)
            {
                if (goi.GetComponent<Aglutine>().aglutine < 3)
                {
                    Vector3 directionToTarget = goi.transform.position - curPos;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistance)
                    {
                        closestDistance = dSqrToTarget;
                        closest = goi;
                    }
                }
            }
            //En sortie de boucle closest est le gameObject de l'ennemi le plus proche.
            if(closest != null)
                go.transform.position = Vector3.MoveTowards(curPos, closest.transform.position, Time.deltaTime * go.GetComponent<Move>().speed);
        }

        foreach (GameObject go in _anticorpVirusGO)
        {
            //Calcul du plus proche :
            float closestDistance = Mathf.Infinity;
            GameObject closest = null;
            Vector3 curPos = go.transform.position;
            foreach (GameObject goi in _hostileVirusGO)
            {
                if (goi.GetComponent<Aglutine>().aglutine < 3)
                {
                    Vector3 directionToTarget = goi.transform.position - curPos;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistance)
                    {
                        closestDistance = dSqrToTarget;
                        closest = goi;
                    }
                }
            }
            //En sortie de boucle closest est le gameObject de l'ennemi le plus proche.
            if (closest != null)
                go.transform.position = Vector3.MoveTowards(curPos, closest.transform.position, Time.deltaTime * go.GetComponent<Move>().speed);
        }

        foreach (GameObject go2 in _triggeredGO)
        {
            GameObject closest = go2.GetComponent<Triggered2D>().Targets[0];
            /*Triggered2D t2d =*/ go2.GetComponent<Triggered2D>();

            if (closest.GetComponent<Aglutine>() != null && closest.GetComponent<Aglutine>().aglutine < 3 && closest.GetComponent<Bacterie>())
            {
                GameObjectManager.removeComponent<Move>(go2);
                GameObjectManager.removeComponent<TriggerSensitive2D>(go2);
                GameObjectManager.removeComponent<CircleCollider2D>(go2);
                //GameObjectManager.removeComponent<AnticorpBacterie>(go2);
                closest.GetComponent<Aglutine>().aglutine += 1;
                closest.GetComponent<Move>().speed *= 0.5f;
                GameObjectManager.setGameObjectParent(go2, closest, true);
            }


        }

       foreach (GameObject go2 in _triggeredAVGO)
        {
            GameObject closest = go2.GetComponent<Triggered2D>().Targets[0];
            /*Triggered2D t2d =*/ go2.GetComponent<Triggered2D>();

            if (closest.GetComponent<Aglutine>() != null && closest.GetComponent<Aglutine>().aglutine < 3 && closest.GetComponent<Virus>())
            {
                GameObjectManager.removeComponent<Move>(go2);
                GameObjectManager.removeComponent<TriggerSensitive2D>(go2);
                GameObjectManager.removeComponent<CircleCollider2D>(go2);
                //GameObjectManager.removeComponent<AnticorpVirus>(go2);
                closest.GetComponent<Aglutine>().aglutine += 1;
                closest.GetComponent<Move>().speed *= 0.5f;
                GameObjectManager.setGameObjectParent(go2, closest, true);
            }


        }
    }
}