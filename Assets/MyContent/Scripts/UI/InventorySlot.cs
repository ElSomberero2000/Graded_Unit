using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon; // Adds corresponding image to the inventory slot panel
        icon.enabled = true; // Makes image visible
        removeButton.interactable = true; // Makes remove button visible when item is in inventory
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null; // Removes image from the inventory slot panel
        icon.enabled = false; // Makes image invisible
        removeButton.interactable = false; // Makes remove button invisible when item is in inventory
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use(); // When the item icom is pressed the use item action occurs
        }
    }
}
