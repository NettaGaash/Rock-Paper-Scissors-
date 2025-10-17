using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayableCharacter playableCharacter;

    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private Animator animator;

    //Movement
    public Vector2 inputVector { get; private set; }

    public Vector3 MousePosition { get; private set; }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        inputVector = new Vector2(h, v);

        MousePosition = Input.mousePosition;

        //isMoving animation 

        if (animator != null)
        {

            if (h != 0 || v != 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
            //Press E button Interact
            if (Input.GetKeyDown(KeyCode.E))
        {
            playableCharacter.SpecialAbility();
            animator.SetTrigger("isUsingSpecialAbility");
        }

        //Press P button PlayerSwitch
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerManager.SwitchPlayer();
        }
    }



}
