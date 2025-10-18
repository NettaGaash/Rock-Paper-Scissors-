using UnityEngine;

public class RockPlayer : PlayableCharacter
{

    public override void SpecialAbility()
    {
        Debug.Log("Rock Interact");

        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, specialAbilityDistance, specialAbilityLayerMask))
        {
            Trap hitTrap = hitInfo.transform.GetComponent<Trap>();
            hitTrap.Interact();
        }

    }

}
