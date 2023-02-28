using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField]
    private GameObject pauseGameUI;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject endGameUI;
    [SerializeField]
    private TextMeshProUGUI endText;
    [SerializeField]
    private ScoreManager scoreManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        pauseGameUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseGameUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void EndGame()
    {
        endGameUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (scoreManager.score > scoreManager.highscore)
        {
            endText.text = "You are amazing\nNew highscore: " + scoreManager.score.ToString();
        }
        else
        {
            endText.text = "Try again\nYour score: " + scoreManager.score.ToString();
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
