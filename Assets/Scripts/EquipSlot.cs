using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : InventorySlot
{
    public override void OnRemoveButton()
    {
        Inventory.inventory.Add(item);
    }

    public void BackToInventory()
    {
        Inventory.inventory.Add(item);

        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

}
