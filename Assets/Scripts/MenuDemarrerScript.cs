using UnityEngine;
using System.Collections;

public class MenuDemarrerScript : MonoBehaviour {
    
    public void LoadScene( string name)
    {
        Application.LoadLevel(name);


    }

    public void QuitGame()
    {
        Application.Quit();
        
    }


}
