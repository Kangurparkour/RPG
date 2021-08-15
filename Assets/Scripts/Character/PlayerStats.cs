using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    private void Start()
    {
        EquipmentMenager.equipment.onEquipmentChange += OnEquipmentChange;
    }


    void OnEquipmentChange(Equipment newItem, Equipment oldItem)
    {

        if (newItem != null)
        {
            Armor.AddModifier(newItem.armorModifier);
            attackDemage.AddModifier(newItem.damageModifier);
        }

        if(oldItem != null)
        {
            Armor.RemoveModifier(oldItem.armorModifier);
            attackDemage.RemoveModifier(oldItem.damageModifier);
        }


    }



}
