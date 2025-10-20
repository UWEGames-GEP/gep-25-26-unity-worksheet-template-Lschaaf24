using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
{
    [SerializeField]
    private InventoryItem currentItem;
    [SerializeField]
    private Inventory parentInventory;
    [SerializeField]
    private Image icon;

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

        if (item != null && icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
        else 
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        originalParent = icon.transform.parent;
        icon.transform.SetParent(canvas.transform);
        icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        icon.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        icon.transform.SetParent(originalParent);
        icon.transform.localPosition = Vector3.zero;
        icon.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedIcon = eventData.pointerDrag.GetComponent<InventorySlot>();
        if(draggedIcon != null && draggedIcon != this && draggedIcon.currentItem != null)
        {
            var item = draggedIcon.currentItem;

            draggedIcon.parentInventory.RemoveItem(item, 1);
            parentInventory.AddItem(item);

            InventoryUI.Instance.RefreshUI();
        }
    }



}
