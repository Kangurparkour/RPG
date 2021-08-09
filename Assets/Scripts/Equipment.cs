using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;
    public Mesh mesh;

    private void Awake()
    {
       
    }


    public override void Use()
    {
        base.Use();
        EquipmentMenager.equipment.Equip(this);
        UpdateWear();
        RemoveFormInventory();
    }


    private void UpdateWear()
    {
      

    }


}


public enum EquipmentSlot { Helmet, Arms, Armor, Legs, RHand, LHand }
