using UnityEngine;

public class PaperPlayer : PlayableCharacter
{

    public override void SpecialAbility()
    {
        base.SpecialAbility();
        Debug.Log("Paper Interact");
    }


}
