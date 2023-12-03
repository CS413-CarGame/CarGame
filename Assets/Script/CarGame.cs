using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Check for tutorial ending condition

public class CarGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scoreText.text);
        if (KillZomb.killedCount >= 10)
        {
            SceneManager.LoadScene("MainMenu");
            KillZomb.killedCount = 0;
        }
    }
}
