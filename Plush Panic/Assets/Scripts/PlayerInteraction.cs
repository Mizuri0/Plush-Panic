using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public KeyCode pickUpKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.Q;
    private GameObject itemToPickUp;

    void Update()
    {
        if (Input.GetKeyDown(pickUpKey))
        {
            PickUpItem();
        }

        if (Input.GetKeyDown(dropKey))
        {
            DropItem();
        }
    }

    private void PickUpItem()
    {
        if (itemToPickUp != null)
        {
            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.transform.childCount == 0)
                {
                    GameObject item = Instantiate(itemToPickUp);
                    item.transform.SetParent(slot.transform);
                    item.transform.localPosition = Vector3.zero;
                    item.GetComponent<DraggableItem>().parentAfterDrag = slot.transform;
                    Destroy(itemToPickUp);
                    itemToPickUp = null;
                    break;
                }
            }
        }
    }

    private void DropItem()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.transform.childCount > 0)
            {
                Transform item = slot.transform.GetChild(0);
                item.SetParent(null);
                item.position = transform.position + transform.forward; // Drops the item in front of the player
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemToPickUp = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (itemToPickUp == other.gameObject)
            {
                itemToPickUp = null;
            }
        }
    }
}