using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SOInventory playerInventory;

    public bool CanCollect { get; set; }
    public GameObject CollectingItem { get; set; }
    
    InventoryUIController inventoryUIController;
    ProgressBar progressBar;

    private void Awake()
    {
        CanCollect = true;
        progressBar = GetComponent<ProgressBar>();
        inventoryUIController = GetComponent<InventoryUIController>();
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mine") && CanCollect == true)
        {
            if (playerInventory.CheckInventory(other.gameObject.GetComponent<Item>().item))
            {
                progressBar.SetPositionBar();
                CollectingItem = other.gameObject;
                CollectingItem.GetComponent<Item>().Collecting();
                CanCollect = false;
            }   
        }
        
        if (CanCollect == false && CollectingItem == other.gameObject)
        {
            if (progressBar.IncreaseProgress(0.01f))
            {
                if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
                {
                    CollectingItem.tag = "Untagged";
                    CollectingItem.GetComponent<Item>().GetItem(this.gameObject);
                    inventoryUIController.UpdateUI();

                    progressBar.ResetProgress();
                    CanCollect = true;
                    CollectingItem = null;
                }          
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == CollectingItem)
        {
            progressBar.ResetProgress();
            CanCollect = true;
            CollectingItem = null;
        }
    }
}
