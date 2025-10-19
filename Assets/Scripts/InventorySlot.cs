using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
{
    public InventoryItem currentItem;
    public Inventory parentInventory;
    public Image icon;

    private Transform originalParent;
    private Canvas canvas;
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }
    public void setItem(InventoryItem item, Inventory inventory)
    {
        currentItem = item;
        parentInventory = inventory;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
