using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private InventoryItem currentItem;
    [SerializeField]
    private Inventory parentInventory;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image highlight;

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

        //eventData.pointerDrag = gameObject;

        originalParent = icon.transform.parent;
        icon.transform.SetParent(canvas.transform);
        icon.transform.SetAsLastSibling();
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

    public void ReplaceItem(InventoryItem newItem, Inventory newParentInventory)
    {
        currentItem = newItem;
        parentInventory = newParentInventory;

        if (icon != null )
        {
            if(newItem != null)
            {
                icon.sprite = newItem.icon;
                icon.enabled = true;
            }
            else
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag.GetComponent<InventorySlot>();


        if(draggedSlot != null && draggedSlot != this)
        {
            InventoryItem draggedItem = draggedSlot.currentItem;
            Inventory draggedParent = draggedSlot.parentInventory;

            InventoryItem currentSlotItem = currentItem;
            Inventory currentSlotParent = parentInventory;

            draggedParent.RemoveItem(draggedItem);
            parentInventory.AddItem(draggedItem);

            if (currentSlotItem != null)
            {
                currentSlotParent.RemoveItem(currentSlotItem);
                draggedParent.AddItem(currentSlotItem);
            }

            this.ReplaceItem(draggedItem, parentInventory);
            draggedSlot.ReplaceItem(currentSlotItem, draggedParent);

            //var item = draggedIcon.currentItem;

            //draggedIcon.parentInventory.RemoveItem(item);
            //parentInventory.AddItem(item);

            //InventoryUI.Instance.RefreshUI();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (highlight != null) highlight.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (highlight != null) highlight.enabled = false;
    }
}
