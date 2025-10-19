using UnityEngine;

public class ScissorsPlayer : PlayableCharacter
{

    public override void SpecialAbility()
    {
        base.SpecialAbility();
        Debug.Log("Scissors Interact");
    }


}


