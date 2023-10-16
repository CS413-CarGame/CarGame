using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void LoadMainGame()
    {
        SceneManager.LoadScene("Demo");
        Time.timeScale = 0f;
    }

    public void StartTutorial()
    {
        Time.timeScale = 1f;
    }
}
