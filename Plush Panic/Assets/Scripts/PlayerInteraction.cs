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
            Debug.Log("E key pressed");
            PickUpItem();
        }

        if (Input.GetKeyDown(dropKey))
        {
            Debug.Log("Q key pressed");
            DropItem();
        }
    }

    private void PickUpItem()
    {
        if (itemToPickUp != null)
        {
            Debug.Log("Item to pick up: " + itemToPickUp.name);
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
                    Debug.Log("Item picked up and placed in inventory");
                    break;
                }
            }
        }
        else
        {
            Debug.Log("No item to pick up");
        }
    }private void DropItem()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.transform.childCount > 0)
            {
                Transform item = slot.transform.GetChild(0);
                item.SetParent(null);
                item.position = transform.position + transform.forward; // Drops the item in front of the player
                item.gameObject.AddComponent<Rigidbody>(); // Optional: add Rigidbody for physics interaction
                Debug.Log("Item dropped from inventory");
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemToPickUp = other.gameObject;
            Debug.Log("Item entered pickup range: " + itemToPickUp.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (itemToPickUp == other.gameObject)
            {
                itemToPickUp = null;
                Debug.Log("Item exited pickup range");
            }
        }
    }
}