using UnityEngine;

public class RockPlayer : PlayableCharacter
{

    public override void SpecialAbility()
    {
        base.SpecialAbility();
        Debug.Log("Rock Interact");

    }

}
