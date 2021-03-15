using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShip : MonoBehaviour
{
    public GameObject[] ships;
    public GameObject[] shipsSecond;
    int countShip;

    private float rotateSpeedModifier = 3f;
    Touch touch;

    private void Start()
    {
        countShip = ships.Length - 1;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            float touchFing = touch.deltaPosition.x * rotateSpeedModifier * Mathf.Deg2Rad;
            ships[countShip].transform.RotateAround(Vector3.up, touchFing);   
        }
    }
    public void LeftChange()
    {
        ships[countShip].SetActive(false);
        shipsSecond[countShip].SetActive(false);
        if (countShip == 0)
            countShip = ships.Length - 1;
        else
            countShip--;
        ships[countShip].SetActive(true);
        shipsSecond[countShip].SetActive(true);

    }
    public void RightChange()
    {
        shipsSecond[countShip].SetActive(false);
        ships[countShip].SetActive(false);
        if (countShip == ships.Length - 1)
            countShip = 0;
        else
            countShip++;
        ships[countShip].SetActive(true);
        shipsSecond[countShip].SetActive(true);
    }
    public void RotateUp()
    {
        shipsSecond[countShip].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void RotateLeft()
    {
        shipsSecond[countShip].transform.rotation = Quaternion.Euler(0f, -90f, -90f);
    }
    public void RotateDown()
    {
        shipsSecond[countShip].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
    public void RotateFace()
    {
        shipsSecond[countShip].transform.rotation = Quaternion.Euler(-90f, -180f, 0f);
    }

    public void ChangeColorRed()
    {
        ships[countShip].GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;

    }
    public void ChangeColorBlue()
    {
        ships[countShip].GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
    }

    public void ChangeColorYellow()
    {
        ships[countShip].GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
    }

    public void ChangeColorGreen()
    {
        ships[countShip].GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
    }

}
