using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene Loading Manager
// Reset kill count on scene change

public class LoadGame : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Demo");
        Time.timeScale = 0f;
        KillZomb.killedCount = 0;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainGame");
        KillZomb.killedCount = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
        KillZomb.killedCount = 0;
    }

    public void StartTutorial()
    {
        Time.timeScale = 1f;
        KillZomb.killedCount = 0;
    }
}
