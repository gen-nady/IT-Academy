using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerController player;
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.isMagnet)
            if (Vector3.Distance(transform.position, player.transform.position) < 10)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 20);
    }
}
