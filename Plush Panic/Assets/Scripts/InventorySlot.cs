using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems; 

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void Ondrop(PointerEventData eventData) {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>(); 
        draggableItem.parentAfterDrag = transform; 
    } 

}