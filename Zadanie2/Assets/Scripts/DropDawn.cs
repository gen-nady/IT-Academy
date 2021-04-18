using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDawn : MonoBehaviour
{
    public TextMeshProUGUI output;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            output.text = "Option A";
        }
        if (val == 1)
        {
            output.text = "Option B";
        }
        if (val == 2)
        {
            output.text = "Option C";
        }
        if (val == 3)
        {
            output.text = "Option D";
        }
    }

    
}
