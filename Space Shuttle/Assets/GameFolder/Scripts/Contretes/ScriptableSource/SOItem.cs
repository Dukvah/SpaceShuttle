using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Item")] 

public class SOItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public int itemValue;

}
