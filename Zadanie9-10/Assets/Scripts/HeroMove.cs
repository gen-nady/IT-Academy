using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMove : MonoBehaviour, Move
{
    public Rigidbody2D rbHero;

    public float speed = 12f;
    public float forceJump;
    float vectorMove;
    static float GroundRadius = 0.1f;
    public Transform GroundCheck;
    public LayerMask WhatIsGround;
    bool IsGrounded;
    public Text coinTxt;
    void FixedUpdate()
    {  
        Move();
    }

    public void Jump()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, WhatIsGround);
        if (IsGrounded)
            rbHero.AddForce(new Vector2(0, forceJump));
    }

    public void Move()
    {
        rbHero.velocity = new Vector2(vectorMove * speed * Time.fixedDeltaTime, rbHero.velocity.y);
    }
    public void MoveLeft()
    {
        vectorMove = -1;
    }
    public void MoveRight()
    {
        vectorMove = 1;
    }
    public void MoveStay()
    {
        vectorMove = 0;
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Coin"))
        {
            int coin = int.Parse(coinTxt.text);
            coin++;
            coinTxt.text = coin.ToString();
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("1");
            Destroy(coll.transform.root.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EnemyDestroy")
        {
            Application.LoadLevel(0);
            Debug.Log("2");
 
        }
       
    }
}
