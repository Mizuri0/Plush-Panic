using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    // Drag and drop 
    public void OnBeginDrag(PointerEventData evenData) 
    { 
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData evenData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData evenData) 
    {
        image.raycastTarget = true;
    }
}
