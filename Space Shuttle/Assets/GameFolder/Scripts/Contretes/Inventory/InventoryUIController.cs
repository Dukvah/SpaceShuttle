using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public List<SlotUI> uiList = new List<SlotUI>();

    Inventory userInventory;

    private void Awake()
    {
        userInventory = GetComponent<Inventory>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (userInventory.playerInventory.inventorySlots[i].itemCount > 0)
            {
                uiList[i].itemImage.sprite = userInventory.playerInventory.inventorySlots[i].item.itemIcon;
                uiList[i].itemCountText.text = $"x{userInventory.playerInventory.inventorySlots[i].itemCount.ToString()}";
                
                uiList[i].gameObject.SetActive(true);
            }
            else
            {
                uiList[i].gameObject.SetActive(false);
            }
        }
    }
}
