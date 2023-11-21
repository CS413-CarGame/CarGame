using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;

    public static int scorePass = 0;

    public TextMeshProUGUI scoreText;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        score += value;
        scorePass = score;
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void SaveHighScore()
    {
         PlayerPrefs.SetInt("HighScore", highScore);
         PlayerPrefs.Save();
    }
}
