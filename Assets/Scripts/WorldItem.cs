using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public InventoryItem inventoryItem;
    private bool pickedUp = false;
    public void Interact(PlayerInventory inventory)
    {
        if (pickedUp) return;
        pickedUp = true;
        if(inventoryItem == null) return; 

        inventory.AddItem(inventoryItem);

        Destroy(gameObject);
    }
}
