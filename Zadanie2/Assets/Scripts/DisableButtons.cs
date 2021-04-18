using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtons : MonoBehaviour
{
    public List<Button> buttons;

    public void Disable()
    {
        foreach (var item in buttons)
        {
            item.interactable = false;
        }
    }

}
