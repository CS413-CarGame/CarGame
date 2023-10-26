using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Demo");
        Time.timeScale = 0f;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartTutorial()
    {
        Time.timeScale = 1f;
    }
}
