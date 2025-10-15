using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();
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

    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItem(string itemName) 
    { 
        items.Remove(itemName); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            items.Add(collisionItem.name);

            Destroy(collisionItem.gameObject);
        }

    }
}
