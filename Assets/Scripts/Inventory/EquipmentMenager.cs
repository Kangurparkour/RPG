using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenager : MonoBehaviour
{
    #region Singleton

    public static EquipmentMenager equipment;

    private void Awake()
    {
        equipment = this;
    }

    #endregion
    public SkinnedMeshRenderer[] skinRenderer; // head / arms / body / shoes ^^
    public MeshFilter rightHand;
    Equipment[] currentEquipment;

    public EquipSlot[] equipSlotUI; 
    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.inventory;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnEquipAll();
    }


    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        equipSlotUI[slotIndex].icon.sprite = newItem.icon;
        equipSlotUI[slotIndex].icon.enabled = true;

        if (slotIndex <= 3)
            skinRenderer[slotIndex].sharedMesh = newItem.mesh;
        else if (slotIndex == 4)
            rightHand.mesh = newItem.mesh;

    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
            skinRenderer[slotIndex].sharedMesh = oldItem.mesh;

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }

        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

}
