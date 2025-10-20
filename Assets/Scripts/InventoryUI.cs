using System;
using UnityEditor.Callbacks;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    private PlayerInventory playerInventory;
    private WeaponRackInventory currentRack;

    public GameObject playerSlotParent;
    public GameObject rackSlotParent;
    public GameObject slotPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        playerInventory = FindAnyObjectByType<PlayerInventory>();
        playerSlotParent.SetActive(false);
        rackSlotParent.SetActive(false);
    }
    public void Open(WeaponRackInventory rack)
    {
        currentRack = rack;
        rackSlotParent.SetActive(true);
        playerSlotParent.SetActive(true);
        RefreshUI();

    }
    public void Close()
    {
        rackSlotParent.SetActive(false);
        playerSlotParent.SetActive(false);
    }
    public void RefreshUI()
    {
        ClearSlots(playerSlotParent.transform);
        ClearSlots(rackSlotParent.transform);

        foreach (InventoryItem item in playerInventory.items)
        {
            CreateSlot(item, playerInventory, playerSlotParent.transform);
        }

        foreach (InventoryItem item in currentRack.items)
        {
            CreateSlot(item, currentRack, rackSlotParent.transform);
        }
        
    }

    private void CreateSlot(InventoryItem item, Inventory inventory, Transform parent)
    {
        GameObject slotGen = Instantiate(slotPrefab, parent);
        InventorySlot slot = slotGen.GetComponent<InventorySlot>();
        slot.setItem(item, inventory);
    }

    private void ClearSlots(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
