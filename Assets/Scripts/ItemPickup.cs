using UnityEngine;

public class ItemPickup : Interaction
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
      //  Debug.Log("Picking " + item.name);
        bool isPickedUp = Inventory.inventory.Add(item);
        if (isPickedUp)
            Destroy(this.gameObject);
    }

}
