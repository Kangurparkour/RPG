using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    protected Item item;


    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void Clear()
    {
        item = null;
        
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    virtual public void OnRemoveButton()
    {
        Inventory.inventory.Remove(item);   
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }


}
