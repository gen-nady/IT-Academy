using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    public Text scoreText;
    public Text coinText;
    public int coin = 0;
    public int score;
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
    public void RestartLvl()
    { 
         
    }
}
