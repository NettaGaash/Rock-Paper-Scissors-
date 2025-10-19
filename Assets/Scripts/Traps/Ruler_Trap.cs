using UnityEngine;

public class Ruler_Trap : Trap
{
    [SerializeField]
    private Animator animator;
    public override void Interact()
    {
        animator.SetTrigger("Fall");
    }

}