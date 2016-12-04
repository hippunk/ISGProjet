using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{

    private bool active;
    public GameObject loop;
    public GameObject canvasVictoire;
    public GameObject canvasDefaite;
    public GameObject canvasPause;
    public GameObject canvasInfo;
    public Object sceneSuivante;
    public Object sceneActuelle;

    void Start()
    {
        canvasVictoire.SetActive(false);
        canvasDefaite.SetActive(false);
        canvasPause.SetActive(false);
        canvasInfo.SetActive(false);
        loop.SetActive(false);
        active = false;
        info();
    }

    void Update()
    {
        if (!active && Input.GetKeyDown(KeyCode.Escape)) {
            pause();
        }

    }

    void pause()
    {
        canvasPause.SetActive(true);
        loop.SetActive(false);
        active = true;
    }

    public void victoire()
    {
        canvasVictoire.SetActive(true);
        loop.SetActive(false);
        active = true;
    }

    public void defaite()
    {
        canvasDefaite.SetActive(true);
        loop.SetActive(false);
        active = true;
    }

    public void info()
    {
        canvasPause.SetActive(false);
        canvasInfo.SetActive(true);
        loop.SetActive(false);
        active = true;
    }

    public void menu()
    {
        SceneManager.LoadScene("SelectionNiveau");
    }

    public void retour()
    {
        loop.SetActive(true);
        canvasPause.SetActive(false);
        canvasInfo.SetActive(false);
        active = false;
    }

    public void recommencer()
    {
        SceneManager.LoadScene(sceneActuelle.name);
    }
    public void suivant()
    {
        SceneManager.LoadScene(sceneSuivante.name);
    }

}