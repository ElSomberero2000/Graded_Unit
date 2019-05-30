using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); // When the scrollwheel is used the inventory will open
        }
     if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); // Allows the inventory to be opened / closed both ways
        }
    }   

    void UpdateUI() // Allows the inventory UI to update when required
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]); // if an item is picked up and there is spaces available it will be added to the inventory screen
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
