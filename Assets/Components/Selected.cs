using UnityEngine;

public class Selected : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	// Le point de la map vers lequel la défense se déplace
	public Vector3 goalPosition;
	// Nous dit si l'entité est en chemin vers sa position but
	public bool en_route = false;
	// Détermine si l'entité peut encore changer de position but
	public bool can_change_goal = true;
}