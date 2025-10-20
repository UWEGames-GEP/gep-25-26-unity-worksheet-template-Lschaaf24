using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    private float playerInteractionRange = 5.0f;
    public LayerMask objectLayer;
    public GameObject interactionUI;
    private WeaponRackInventory rackInventory;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryUI.Instance.Open(rackInventory);
            }
        }
        else
        {
            interactionUI.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryUI.Instance.Close();
            }
        }
    }

}


