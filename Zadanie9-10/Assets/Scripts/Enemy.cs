using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 7f;
	float direction = -1f;
	Rigidbody2D rb;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb.velocity = new Vector2(speed * direction, rb.velocity.y);
		transform.localScale = new Vector3(direction, 1, 1);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
			direction *= -1f;
		if (coll.gameObject.tag == "EnemyDestroy")
			direction *= -1f;
	}
}
