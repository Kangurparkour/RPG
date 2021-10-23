using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction
{

    public override void Interact()
    {
        base.Interact();

        Debug.Log("W czym mogę służyć wędrowcze ?");
    }

}
