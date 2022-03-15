using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
 
    [SerializeField]
    public string Scenename;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Scenename);
    }


    public void LoadScene(string name)
    {
        // this is the ticket for PirateHub
        SceneManager.LoadScene(name);
        
    }
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
    

   
}
