using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class LifeSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _combatGO = FamilyManager.getFamily(
        new AllOfComponents(typeof(Attack), typeof(Life), typeof(Triggered2D)) , new NoneOfComponents(typeof(Bacterie)));
	private Family _lifeSystemGO = FamilyManager.getFamily(
		new AllOfComponents(typeof(Life)));


    protected override void onPause(int currentFrame) {

    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _combatGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();

			//Gestion des Dégats :
			if (t2d != null) {
				foreach (GameObject target in t2d.Targets) {
					if (target.GetComponent<Life> () != null) {

						if (go.GetComponent<Macrophage> () && ((target.GetComponent<Virus> () && (target.GetComponent<Aglutine> ().aglutine > 0)) 
							|| (target.GetComponent<Bacterie> () /*&& target.GetComponent<Infecte> () == null*/) 
							|| target.GetComponent<Dechet> () 
							|| target.GetComponent<Toxine> ())) {
							//Debug.Log (target);
							//Debug.Log (go);
							target.GetComponent<Life> ().life -= go.GetComponent<Attack> ().attack;
							go.GetComponent<Life> ().life -= target.GetComponent<Attack> ().attack;

						}
						if (go.GetComponent<T8> () && (target.GetComponent<Infecte>() && (target.GetComponent<Infecte>() || target.GetComponent<Cellule>()))) {
							//Debug.Log (target);
							//Debug.Log (go);
							target.GetComponent<Life> ().life -= go.GetComponent<Attack> ().attack;
							//go.GetComponent<Life> ().life -= target.GetComponent<Attack> ().attack;

						}
						if (go.GetComponent<Toxine> () && (target.GetComponent<Defenses>() && target.GetComponent<Macrophage>() == null)) {
							//Debug.Log (target);
							//Debug.Log (go);
							target.GetComponent<Life> ().life -= go.GetComponent<Attack> ().attack;
							go.GetComponent<Life> ().life = 0;

						}

					}
				}

			}
		}
		foreach (GameObject go in _lifeSystemGO){
		//Gestion de la mort
			if (go.GetComponent<Defenses> ()){
				if (go.GetComponent<Life>().life <= 0)
				{                                    
					for (int i = 0; i < 10; i++)
					{
						//GameObjectManager.instantiatePrefab("dechet").transform.position = go.transform.position;
						GameObject obj = GameObject.Instantiate ((GameObject)Resources.Load ("dechet"));
						obj.transform.position = go.transform.position;    
						GameObjectManager.bind (obj);
					}

					//GameObjectManager.destroyGameObject(go);
					GameObjectManager.unbind (go);
					GameObject.Destroy (go);
				}
			}

			if (go.GetComponent<Bacterie> ()){
				if (go.GetComponent<Life>().life <= 0)
				{
					for (int i = 0; i < 3; i++)
					{
						//GameObjectManager.instantiatePrefab("dechet").transform.position = go.transform.position;
						GameObject obj = GameObject.Instantiate ((GameObject)Resources.Load ("dechet"));
						obj.transform.position = go.transform.position;    
						GameObjectManager.bind (obj);

					}
					//GameObjectManager.destroyGameObject(go);
					GameObjectManager.unbind (go);
					GameObject.Destroy (go);
				}
			}
			if (go.GetComponent<Virus> ()){
				if (go.GetComponent<Life>().life <= 0)
				{
					/*for (int i = 0; i < 3; i++)
					{
						GameObjectManager.instantiatePrefab("dechet").transform.position = go.transform.position;
					}*/
					//GameObjectManager.destroyGameObject(go);
					GameObjectManager.unbind (go);
					GameObject.Destroy (go);
				}
			}
			if (go.GetComponent<Dechet> ()){
				if (go.GetComponent<Life>().life <= 0)
				{

					//GameObjectManager.destroyGameObject(go);
					GameObjectManager.unbind (go);
					GameObject.Destroy (go);
				}
			}
			if (go.GetComponent<Toxine> ()){
				if (go.GetComponent<Life>().life <= 0)
				{

					//GameObjectManager.destroyGameObject(go);
					GameObjectManager.unbind (go);
					GameObject.Destroy (go);
				}
			}

		}


    }
}