using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
       highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}