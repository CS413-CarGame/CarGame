using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scoreText.text);
        if (scoreText.text == "Score: 1000")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
