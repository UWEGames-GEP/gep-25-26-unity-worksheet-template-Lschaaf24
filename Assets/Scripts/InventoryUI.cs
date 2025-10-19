using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    private PlayerInventory playerInventory;
    private WeaponRackInventory currentRack;

    public Transform playerSlotParent;
    public Transform rackSlotParent;
    public GameObject slotPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        playerInventory = FindAnyObjectByType<PlayerInventory>();
        gameObject.SetActive(false);
    }
    void Open(WeaponRackInventory rack)
    {
        currentRack = rack;
        gameObject.SetActive(true);
        RefreshUI();
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    private void RefreshUI()
    {
        ClearSlots(playerSlotParent);
        ClearSlots(rackSlotParent);

        foreach (var item in playerInventory.items)
        {
            CreateSlot(item, playerInventory, playerSlotParent);
        }
        foreach (var item in currentRack.items)
        {
            CreateSlot(item, currentRack, rackSlotParent);
        }
        
    }

    private void CreateSlot(InventoryItem item, Inventory inventory, Transform parent)
    {
        var slotGO = Instantiate(slotPrefab, parent);
        var slot = slotGO.GetComponent<InventorySlot>();
        
    }

    private void ClearSlots(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
