using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    //private GameManager gamemanager;

    void Start()
    {
        //gamemanager = FindAnyObjectByType<GameManager>();
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

    public void RemoveItem(InventoryItem item)
    {
        var existing = items.Find(i => i.itemName == item.itemName);
        if (existing != null)
        {
            existing.quantity -= item.quantity;
            if(existing.quantity <= 0)
            {
                items.Remove(existing);
            }
        }
        
    }

    // private void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

    //     if (collisionItem != null)
    //     {
    //         items.Add(collisionItem.name);

    //         Destroy(collisionItem.gameObject);
    //     }

    // }
}
