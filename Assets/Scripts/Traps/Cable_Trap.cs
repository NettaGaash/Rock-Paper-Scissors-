using UnityEngine;

public class Cable_Trap : Trap
{
    [SerializeField]
    private Animator animator;
    public override void Interact()
    {
        animator.SetTrigger("isDestroyed");
    }

}