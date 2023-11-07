using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
   public GameObject pauseMenuUI;
   private bool isPaused = false;

   void Awake()
   {
      pauseMenuUI.SetActive(false);
   }
   
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

   public void Resume()
   {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
   }

   void Pause()
   {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
   }

   public void LoadMenu()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
   }
}