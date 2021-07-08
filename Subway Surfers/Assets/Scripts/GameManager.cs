using System.Collections;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [Header("Start Road")]
    public PlatformController startPlatform;
    [Header("Player")]
    [SerializeField]
    PlayerController player;
    [Header("Active bonus time")]
    public int activeBonusTime = 10;
    int factorScore = 1;
    int coin = 0;
    float score = 0;

    [HideInInspector]
    public bool isMagnet = false;

    Vector3 playerStartPosition = new Vector3(-45.5f, 1f, 0f);
    Vector3 platformStartPosition = new Vector3(0f, 0f, 0f);
    private void Awake()
    {
        Time.timeScale = 0f;
        if (PlayerPrefs.GetInt("IsDonate") == 1)
        {
            activeBonusTime = PlayerPrefs.GetInt("BonusTime");
        }
    }
    void Update()
    {
        score += factorScore * PlatformManager.Instanse.speedPlatform*Time.deltaTime;
        UIManager.Instanse.ChangeUIScore(score);
    }
    public void ChangeCoin()
    {
        coin++;
        UIManager.Instanse.ChangeUICoin(coin);
    }
  
    public void DeadPlayer()
    {
        UIManager.Instanse.gamePanel.SetActive(false);
        UIManager.Instanse.deadPanel.SetActive(true);
        Time.timeScale = 0;
        int sumCoin = PlayerPrefs.GetInt("Coin");
        sumCoin += coin;
        PlayerPrefs.SetInt("Coin", sumCoin);
        float maxScore = PlayerPrefs.GetFloat("Score");
        if (score > maxScore)
        {
            PlayerPrefs.SetFloat("Score", score);
            UIManager.Instanse.deadScoreText.text = "New Record!\n" + score.ToString("0");
        }
        else
        {
            UIManager.Instanse.deadScoreText.text = "Score:\n" + score.ToString("0");
        }
    }
    public void RestartLvl()
    {
        for (int i = 0; i < startPlatform.gameObject.transform.childCount; i++)
        {
            startPlatform.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        Time.timeScale = 1;
        PlatformManager.Instanse.ReloadPlatform();
        UIManager.Instanse.deadPanel.SetActive(false);
        UIManager.Instanse.gamePanel.SetActive(true);
        startPlatform.transform.position = platformStartPosition;
        startPlatform.gameObject.SetActive(true);
        player.transform.position = playerStartPosition;
        player.factorForceJump = 1f;
        coin = 0;
        score = 0f;
        factorScore = 1;
        isMagnet = false;
        UIManager.Instanse.scoreText.text = null;
        UIManager.Instanse.coinText.text = null;
    }
    public IEnumerator DoubleScore()
    {
        factorScore = 2;
        yield return new WaitForSeconds(activeBonusTime);
        factorScore = 1;
    }
}
