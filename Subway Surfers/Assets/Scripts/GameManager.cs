using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    public Text scoreText;
    public Text coinText;
    int coin = 0;
    int score = 0;
    Vector3 playerStartPosition = new Vector3(-45.5f, 1f, 0f);
    Vector3 platformStartPosition = new Vector3(0f, 0f, 0f);
    public PlatformController startPlatform;
    public PlayerController player;
    public GameObject pausePanel;
    bool isPaused = false;
    void Start()
    {

    }

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
    public void RestartLvl()
    {
        PlatformManager.Instanse.HidePlatform();
        startPlatform.transform.position = platformStartPosition;
        startPlatform.gameObject.SetActive(true);
        player.transform.position = playerStartPosition;
    }
}
