using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Pause Menu Manager

public class PauseManager : MonoBehaviour
{
   public GameObject pauseMenuUI;
   private bool isPaused = false;

   // Make sure menu doesn't popup
   void Awake()
   {
      pauseMenuUI.SetActive(false);
   }
   
   // Check if escape key is pressed and pause game if it is
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (isPaused)
         {
            Resume();
         }
         else
         {
            Pause();
         }
      }
   }

   // Resume Game
   public void Resume()
   {
      Debug.Log("RESUME");
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
   }

   // pause game
   void Pause()
   {
      Debug.Log("PAUSED");
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
   }

   // Load main menu
   public void LoadMenu()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
   }
}