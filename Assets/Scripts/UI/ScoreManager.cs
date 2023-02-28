using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highscoreText;

    public int score = 0;
    public int highscore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint(int points)
    {
        score += points;
        if (score < 0) score = 0;
        scoreText.text = score.ToString() + " POINTS";
    }

    private void OnDestroy()
    {
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }

    }
}
