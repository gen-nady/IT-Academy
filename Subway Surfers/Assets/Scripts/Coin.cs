using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 transformCoin;
    PlayerController player;
    [SerializeField]
    int speed;
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        transformCoin = transform.localPosition;
    }
    void Update()
    {
        if (GameManager.Instanse.isMagnet)
            if (Vector3.Distance(transform.position, player.transform.position) < 10)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
    private void OnEnable()
    {
       transform.localPosition = transformCoin;
    }
}
