using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInventorySystem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData evenData)
    {
        if (transform.childCount > 0) return;                        // Prevent dropping if this slot already has an item
        GameObject dropped = evenData.pointerDrag;                  // Get the object being dragged
        DragItem draggableItem = dropped.GetComponent<DragItem>(); // Get the DraggableItem component
        draggableItem.originalParent = transform;                 // Set the original parent to this slot
    }

}
