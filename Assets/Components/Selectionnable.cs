using UnityEngine;

public class Selectionnable : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public Sprite sprite;
	// Le point de la map vers lequel la défense se déplace
	public Vector3 goalPosition = Vector3.zero;
}