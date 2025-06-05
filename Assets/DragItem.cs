using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image; // Optional: Reference to an image component if you want to change visuals during drag
    public Transform originalParent;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag started on: " + gameObject.name);
        originalParent = transform.parent;
        transform.SetParent(transform.root); // Move to root to avoid hierarchy issues
        transform.SetAsLastSibling(); // Bring to front
        image.raycastTarget = false; // Disable raycast target if using an image
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging: " + gameObject.name);
        transform.position = eventData.position; // Follow the mouse position
    }
    public void OnEndDrag(PointerEventData eventData)
    {

            Debug.Log("Drag ended on: " + gameObject.name);
            transform.SetParent(originalParent); // Return to original parent
            // Optionally, you can snap the item back to its original position here 
            image.raycastTarget = true; // Re-enable raycast target

    }
}