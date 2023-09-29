using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{   
    //load next scene after the startmenu in build settings
    public void StartMenuButton() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartPlay1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void StartPlay2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void StartPlay3()
    {
        SceneManager.LoadScene("Level3");
    }
    //quit the application by pressing the quit button
    public void QuitPlay()
    {
        Debug.Log("Quit Application"); 
        Application.Quit();
    }
}
