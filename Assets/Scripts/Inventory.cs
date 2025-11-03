using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    [SerializeField]
    private InventoryUI inventory;

    private GameManager gamemanager;

    void Start()
    {
        gamemanager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        //if(gamemanager.state == GameState.GAMEPLAY)
        //{
        //    //if (Input.GetKeyDown(KeyCode.O))
        //    //{
        //    //    AddItem("Generic Item");
        //    //}
        //    //if (Input.GetKeyDown(KeyCode.P))
        //    //{
        //    //    RemoveItem("Generic Item");
        //    //}
        //}
        //else
        //{

        //}

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.OpenPlayer();
            gamemanager.state = GameState.PAUSE;

        }

    }

    public void AddItem(InventoryItem item)
    {
        var existing = items.Find(i => i.itemName == item.itemName);
        if (existing != null)
        {
            existing.quantity += item.quantity;
        }
        else
        {
            items.Add(new InventoryItem
            {
                itemName = item.itemName,
                icon = item.icon,
                prefab = item.prefab
            });
        }

            
    }

    public void RemoveItem(InventoryItem item, int amount)
    {
        var existing = items.Find(i => i.itemName == item.itemName);
        if (existing != null)
        {
            existing.quantity -= amount;
            if(existing.quantity <= 0)
            {
                items.Remove(existing);
            }
        }
        
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

    //    if (collisionItem != null)
    //    {
    //        items.Add(collisionItem.name);

    //        Destroy(collisionItem.gameObject);
    //    }

    //}
}
