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
    public void OpenWeapons(WeaponRackInventory rack)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentRack = rack;
        rackSlotParent.SetActive(true);
        playerSlotParent.SetActive(true);
        RefreshUI();

    }

    public void OpenPlayer()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerSlotParent.SetActive(true);
        RefreshUI();
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rackSlotParent.SetActive(false);
        playerSlotParent.SetActive(false);
    }
    public void RefreshUI()
    {
        ClearSlots(playerSlotParent.transform);
        ClearSlots(rackSlotParent.transform);

        CreateInventorySlots(playerInventory, playerSlotParent.transform);

        if (currentRack != null)
        {
            CreateInventorySlots(currentRack, rackSlotParent.transform);
        }
        
    }

    private void CreateInventorySlots(Inventory inventory, Transform parent)
    {
        int itemCount = inventory.items.Count;

        for (int i = 0; i < itemCount; i++)
        {
            CreateSlot(inventory.items[i], inventory, parent);
        }

        int emptyCount = inventory.maxSlots - itemCount;

        for(int i = 0;i < emptyCount; i++)
        {
            CreateSlot(null, inventory, parent);
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
