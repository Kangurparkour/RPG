using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyInteraction : Interaction
{
    PlayerMenager playerMenager;
    CharacterStats stats;

    private void Start()
    {
        playerMenager = PlayerMenager.playerMenager;
        stats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

        CharacterCombat char_Combat = playerMenager.player.GetComponent<CharacterCombat>();
        if(char_Combat != null)
        {
            char_Combat.Attack(stats);
        }

    }
}
