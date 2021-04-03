using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] background;
    float speed = 2f;
    bool isSwitch=false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isSwitch = !isSwitch;

        for (int i = 0; i < 2; i++)
        {
            if (!isSwitch)
            {
                if (background[i].transform.position.x > -5.5f)
                    background[i].transform.Translate(Vector2.left * Time.deltaTime * speed);
                else
                    background[i].transform.position = new Vector2(13f, background[i].transform.position.y);
            }
            else if (isSwitch)
            {
                if (background[i].transform.position.x < 13f)
                    background[i].transform.Translate(Vector2.right * Time.deltaTime * speed);
                else
                    background[i].transform.position = new Vector2(-5.5f, background[i].transform.position.y);
            }

        }
        for (int i = 2; i < background.Length; i++)
        {
            if (!isSwitch)
            {
                if (background[i].transform.position.x > -5.5f)
                    background[i].transform.Translate(Vector2.left * Time.deltaTime * speed*speed);
                else
                    background[i].transform.position = new Vector2(13f, background[i].transform.position.y);
            }
            else if (isSwitch)
            {
                if (background[i].transform.position.x < 13f)
                    background[i].transform.Translate(Vector2.right * Time.deltaTime * speed* speed);
                else
                    background[i].transform.position = new Vector2(-5.5f, background[i].transform.position.y);
            }

        }
    }
}
