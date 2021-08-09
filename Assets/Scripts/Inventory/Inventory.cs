using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singelton

    public static Inventory inventory;
    private void Awake()
    {
        if (inventory != null)
        {
            Debug.LogWarning("Error");
            return;
        }
        inventory = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCollback;

    public int space = 20;

    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if (!item.isDefoultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Za mało miejsca w plecaku");
                return false;
            }
            items.Add(item);
            if (onItemChangedCollback != null)
                onItemChangedCollback.Invoke();

        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCollback != null)
            onItemChangedCollback.Invoke();
    }
}
