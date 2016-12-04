using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {

    // Use this for initialization

    public GameObject canvasInfo;

    public void retour()
    {

        canvasInfo.SetActive(false);

    }

    public void info()
    {

        canvasInfo.SetActive(true);

    }
}
