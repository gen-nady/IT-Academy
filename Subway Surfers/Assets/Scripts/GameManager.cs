using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("Старотовая дорога")]
    public PlatformController startPlatform;

    [Header("Компоненты Text")]
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text coinText;
    [SerializeField]
    Text deadScoreText;
    [Header("Игрок")]
    [SerializeField]
    PlayerController player;
    [Header("Панель паузы и смерти")]
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject deadPanel;

    int coin = 0;
    int score = 0;

    Vector3 playerStartPosition = new Vector3(-45.5f, 1f, 0f);
    Vector3 platformStartPosition = new Vector3(0f, 0f, 0f);

    bool isPaused = false;

    void FixedUpdate()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    public void ChangeCoin()
    {
        coin++;
        coinText.text = coin.ToString();
    }
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    public void DeadPlayer()
    {
        deadPanel.SetActive(true);
        Time.timeScale = 0;
        int sumCoin = PlayerPrefs.GetInt("Coin");
        sumCoin += coin;
        PlayerPrefs.SetInt("Coin", coin);
        int maxScore = PlayerPrefs.GetInt("Score");
        if (score > maxScore)
        {
            PlayerPrefs.SetInt("Score", score);
            deadScoreText.text = "New Record!\n" + score.ToString();
        }
        else
        {
            deadScoreText.text = "Score:\n" + score.ToString();
        }

    }
    public void RestartLvl()
    {
        Time.timeScale = 1;
        PlatformManager.Instanse.HidePlatform();
        deadPanel.SetActive(false);
        startPlatform.transform.position = platformStartPosition;
        startPlatform.gameObject.SetActive(true);
        player.transform.position = playerStartPosition;
        coin = 0;
        score = 0;
        scoreText.text = null;
        coinText.text = null;
    }
}
