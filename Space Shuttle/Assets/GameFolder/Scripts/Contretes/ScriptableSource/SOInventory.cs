using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")] 

public class SOInventory : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();
    int stackLimit = 9;

    public bool AddItem(SOItem item)
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.item == item)
            {
                if (slot.item.canStackable)
                {
                    if (slot.itemCount < stackLimit)
                    {
                        slot.itemCount++;
                        if (slot.itemCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }

                        return true;
                    }
                } 
            }
            else if(slot.itemCount == 0)
            {
                slot.AddItemToSlot(item);
                return true;
            }
        }

        return false;
    }
}

[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public SOItem item;

    public void AddItemToSlot(SOItem item)
    {
        this.item = item;
        
        if (!item.canStackable)
        {
            isFull = true;
        }
        
        itemCount++;
    }
    
}
