using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInventorySystem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData evenData)
    {
        if (transform.childCount > 0) return; 
        GameObject dropped = evenData.pointerDrag; // Get the object being dragged
        DragItem draggableItem = dropped.GetComponent<DragItem>(); // Get the DraggableItem component
        draggableItem.originalParent = transform;
        
    }

}
/*  public Transform originalParent;
    public Transform currentParent;
    public void OnBeginDrag(PointerEventData eventData)
{
    originalParent = transform.parent;
    currentParent = originalParent; // Store the original parent
    transform.SetParent(originalParent.parent); // Move to the root for dragging
}
public void OnDrag(PointerEventData eventData)
{
    transform.position = eventData.position; // Update position based on mouse
}
public void OnEndDrag(PointerEventData eventData)
{
    transform.SetParent(currentParent); // Return to the original parent
}
public void OnDrop(PointerEventData eventData)
{
    if (eventData.pointerDrag != null)
    {
        DragInventorySystem droppedItem = eventData.pointerDrag.GetComponent<DragInventorySystem>();
        if (droppedItem != null && droppedItem.currentParent != currentParent)
        {
            droppedItem.currentParent = currentParent; // Update the parent of the dropped item
        }
    }
}*/
