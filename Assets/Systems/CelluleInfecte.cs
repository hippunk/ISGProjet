using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class CelluleInfecte : FSystem
{
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _celluleGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Infection),typeof(Triggered2D)));

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        foreach (GameObject go in _celluleGO)
        {
            Triggered2D t2d = go.GetComponent<Triggered2D>();

            foreach (GameObject target in t2d.Targets)
            {
				if (target.GetComponent<Virus>() != null && target.GetComponent<Aglutine>().aglutine == 0) {
					if (go.GetComponent<Infection> ().infection < 1) {
						go.GetComponent<Infection> ().infection += 1;
						if (go.GetComponent<Infection> ().infection >= 1 && !go.GetComponent<Infecte> ()) {
							GameObjectManager.addComponent<Infecte> (go);
							//go.AddComponent<Infecte>();
							//GameObjectManager.bind (go);
							go.GetComponent<SpriteRenderer> ().color = Color.green;
							//GameObjectManager.removeComponent<Cellule>(go);
						}
						//Debug.Log (target);
						//GameObjectManager.destroyGameObject(target);
						target.GetComponent<Life> ().life = 0;
            
					}
				}
			}
        }
    }

}
