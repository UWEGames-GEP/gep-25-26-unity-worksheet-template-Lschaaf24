using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Camera playerCamera;

    private float playerInteractionRange = 10.0f;
    public LayerMask objectLayer;
    private PlayerInventory playerInventory;
    private GameObject interactionUI;
    private bool isOpen = false; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = Camera.main;
        interactionUI = GameObject.Find("Canvas").transform.Find("InteractionUI").gameObject;
        playerInventory = GameObject.Find("PlayerArmature").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, playerInteractionRange, objectLayer))
        {
            interactionUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && isOpen == false)
            {
                var worldItem = hit.collider.GetComponent<WorldItem>();

                if (worldItem != null)
                {
                    worldItem.Interact(playerInventory);
                    return;
                }

                WeaponRackInventory rackInventory = hit.collider.GetComponent<WeaponRackInventory>();

                InventoryUI.Instance.OpenWeapons(rackInventory);
                isOpen = true;

            }
            else if(Input.GetKeyDown(KeyCode.E) && isOpen == true)
            {
                isOpen = false;
                InventoryUI.Instance.Close();
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpen == true)
            {
                isOpen = false;
                InventoryUI.Instance.Close();
            }
            interactionUI.SetActive(false);

        }
    }

}


