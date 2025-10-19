using UnityEngine;

public class Gum_Trap : Trap
{
    [SerializeField]
    private Animator animator;
    public override void Interact()
    {
        animator.SetTrigger("isDestroyed");
    }

}