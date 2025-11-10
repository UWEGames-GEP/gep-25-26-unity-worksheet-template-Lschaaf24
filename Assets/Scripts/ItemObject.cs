using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    private float playerInteractionRange = 5.0f;
    public LayerMask objectLayer;
    public GameObject interactionUI;
    private bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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


