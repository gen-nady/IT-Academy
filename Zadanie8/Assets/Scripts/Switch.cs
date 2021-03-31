
using UnityEngine;

public class Switch : MonoBehaviour
{
    Animator animator;

    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterAnimator.SetTrigger("Switch");
        }
    }
}
