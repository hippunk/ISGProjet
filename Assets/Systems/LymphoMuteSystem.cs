using UnityEngine;
using FYFY;

public class LymphoMuteSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.

    private Family _lymphoGO = FamilyManager.getFamily(new AllOfComponents(typeof(Lympho)));
    private Family _hostileVirusGO = FamilyManager.getFamily(new AllOfComponents(typeof(Virus)));
    private Family _hostileBacterie = FamilyManager.getFamily(new AllOfComponents(typeof(Bacterie)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _lymphoGO)
        {
            //Calcul du plus proche :
            int nbVirus = 0;
            int nbBacteries = 0;

            Vector3 curPos = go.transform.position;

            //Comptage des virus à portée
            foreach (GameObject goi in _hostileVirusGO)
            {

                if((goi.transform.position - curPos).sqrMagnitude < 10)
                {
                    nbVirus++;
                }

            }
            foreach (GameObject goi in _hostileBacterie)
            {

                if ((goi.transform.position - curPos).sqrMagnitude < 10)
                {
                    nbBacteries++;
                }

            }


            if(nbVirus > 0)
            {
                go.GetComponent<Lympho>().cptVir+=nbVirus;
            }
            else
            {
                go.GetComponent<Lympho>().cptVir = 0;
            }

            if (nbBacteries > 0)
            {
                go.GetComponent<Lympho>().cptBac += nbBacteries;
            }
            else
            {
                go.GetComponent<Lympho>().cptBac = 0;
            }

            if (go.GetComponent<Lympho>().cptVir > 100)
            {
                if (go.GetComponent<Selected>() == null)
                {  
                    go.GetComponent<SpriteRenderer>().sprite = go.GetComponent<Lympho>().LymphoVir;
                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<Lympho>().LymphoVirHigh;
                }
                else
                {
                    go.GetComponent<SpriteRenderer>().sprite = go.GetComponent<Lympho>().LymphoVirHigh;
                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<Lympho>().LymphoVir;
                }
                GameObjectManager.removeComponent<Lympho>(go);
                GameObjectManager.addComponent<LymphoVir>(go);
            }
            if (go.GetComponent<Lympho>().cptBac > 100)
            {
                if (go.GetComponent<Selected>() == null)
                {
                    go.GetComponent<SpriteRenderer>().sprite = go.GetComponent<Lympho>().LymphoBac;
                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<Lympho>().LymphoBacHigh;
                }
                else
                {
                    go.GetComponent<SpriteRenderer>().sprite = go.GetComponent<Lympho>().LymphoBacHigh;
                    go.GetComponent<Selectionnable>().sprite = go.GetComponent<Lympho>().LymphoBac;
                }
                GameObjectManager.removeComponent<Lympho>(go);
                GameObjectManager.addComponent<LymphoBac>(go);
            }
        }
    }
}