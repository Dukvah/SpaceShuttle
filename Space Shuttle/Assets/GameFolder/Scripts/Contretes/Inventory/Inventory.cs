using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SOInventory playerInventory;
    
    InventoryUIController inventoryUIController;

    private void Awake()
    {
        inventoryUIController = GetComponent<InventoryUIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mine"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventoryUIController.UpdateUI();
            }
        }
    }
}
