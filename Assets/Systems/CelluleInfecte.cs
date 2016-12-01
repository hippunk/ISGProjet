using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class CelluleInfecte : FSystem
{
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _celluleGO = FamilyManager.getFamily(
        new AllOfComponents(typeof(Cellule), typeof(Triggered2D)));
    private Family _bacterieGO = FamilyManager.getFamily(
       new AllOfComponents(typeof(Bacterie), typeof(Triggered2D)));


    protected override void onPause(int currentFrame)
    {

    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame)
    {
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _celluleGO)
        {
            Triggered2D t2d = go.GetComponent<Triggered2D>();

            if (t2d != null)
            {
                foreach (GameObject target in t2d.Targets)
                {
                    if (target.GetComponent<Virus>() != null)
                    {
                        int nbvirus = go.GetComponent<Cellule>().nbvirus;
                        go.GetComponent<Cellule>().nbvirus = nbvirus + 1;
                        if (go.GetComponent<Cellule>().nbvirus >= 5 && !go.GetComponent<Infecte>())
                        {
                            GameObjectManager.addComponent<Infecte>(go);
                            go.GetComponent<SpriteRenderer>().color = Color.green;
                            GameObjectManager.removeComponent<Cellule>(go);
                        }
 
                        GameObjectManager.destroyGameObject(target);
                        //target.GetComponent<Life>().life = 0;
                    }


                }

            }
        }
        foreach (GameObject go in _bacterieGO)
        {
            Triggered2D t2d = go.GetComponent<Triggered2D>();

            if (t2d != null)
            {
                foreach (GameObject target in t2d.Targets)
                {
                    if (target.GetComponent<Virus>() != null)
                    {
                        int nbvirus = go.GetComponent<Bacterie>().nbvirus;
                        go.GetComponent<Bacterie>().nbvirus = nbvirus + 1;
                        if (go.GetComponent<Bacterie>().nbvirus >= 5 && !go.GetComponent<Infecte>())
                        {
                            GameObjectManager.addComponent<Infecte>(go);
                            go.GetComponent<SpriteRenderer>().color = Color.green;
                            //GameObjectManager.removeComponent<Bacterie>(go);
                        }

                        GameObjectManager.destroyGameObject(target);
                        //target.GetComponent<Life>().life = 0;
                    }


                }

            }


        }

        }
}