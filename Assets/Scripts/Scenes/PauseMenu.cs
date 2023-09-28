using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;


    void Update()
    {
     if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();

            }

        }
     
    }
    public void ResumeGame()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void StartMenuButton()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
 
}
