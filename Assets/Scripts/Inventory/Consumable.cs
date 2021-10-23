using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public int healthToAdd = 15;
    private CharacterStats stats;


    private void Start()
    {
        stats = PlayerMenager.playerMenager.player.GetComponent<CharacterStats>();
    }

    public override void Use()
    {
        base.Use();
        if (stats.currentHealth >= stats.maxHealth)
        {
            Debug.Log("Masz pełne życie!");
            return;
        }


        stats.currentHealth += healthToAdd;
        RemoveFormInventory();

    }

}
