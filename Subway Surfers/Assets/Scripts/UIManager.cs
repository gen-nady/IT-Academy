using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
    [Header("Components Text")]
    public Text scoreText;
    public Text coinText;
    public Text deadScoreText;
    public Text startBestScore;
    public Text startCoin;
    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject deadPanel;
    public GameObject gamePanel;
    public GameObject startPanel;
    bool isPaused = false;
    [SerializeField]
    int priceDonate = 1;
    [SerializeField]
    int donateBonusTime = 1;
    private void OnEnable()
    {
        startBestScore.text = "BEST SCORE\n" + PlayerPrefs.GetFloat("Score").ToString("0");
        startCoin.text = "COIN:\n" + PlayerPrefs.GetInt("Coin").ToString();
    }
    public void ChangeUICoin(int coin)
    {
        coinText.text = coin.ToString();
    }
    public void ChangeUIScore(float score)
    {
        scoreText.text = score.ToString("0");
    }
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = !isPaused;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            isPaused = !isPaused;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }
    public void StartGame()
    {
        Restart();
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void MainMenu()
    {
        startBestScore.text = "BEST SCORE\n" + PlayerPrefs.GetFloat("Score").ToString("0");
        startCoin.text = "COIN:\n" + PlayerPrefs.GetInt("Coin").ToString();
        Time.timeScale = 0f;
        pausePanel.SetActive(false);
        startPanel.SetActive(true);
        deadPanel.SetActive(false);
        gamePanel.SetActive(false);
    }
    public void Donate()
    {
        if (PlayerPrefs.GetInt("Coin") > priceDonate)
        {
            int coin = PlayerPrefs.GetInt("Coin");
            coin -= priceDonate;
            GameManager.Instanse.activeBonusTime += donateBonusTime;
            int donate = 1;
            PlayerPrefs.SetInt("IsDonate", donate);
            PlayerPrefs.SetInt("BonusTime", GameManager.Instanse.activeBonusTime);
            PlayerPrefs.SetInt("Coin", coin);
            startCoin.text = "COIN:\n" + PlayerPrefs.GetInt("Coin").ToString();
        }
    }
    public void Restart()
    {
        GameManager.Instanse.RestartLvl();
    }
}
