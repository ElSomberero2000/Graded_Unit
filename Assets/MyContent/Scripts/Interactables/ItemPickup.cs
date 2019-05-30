using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact() // Called when interacting with a valid object in the scene
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    { 
        Debug.Log("Picking up " + item.name);
        // Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject); // When the item is picked up it is removed from the scene
    }

}
