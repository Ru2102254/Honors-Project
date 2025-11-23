using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    public event EventHandler OnItemListChanged;
    private List<ItemTypeScript> ItemTypeList;

    public InventoryScript()
    {
        ItemTypeList = new List<ItemTypeScript>();

        AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });
        Debug.Log(ItemTypeList.Count);
    }

    public void AddItem(ItemTypeScript item)
    {
        if (item.IsStackable())
        {
            bool itemInInventory = false;
            foreach (ItemTypeScript InventoryItem in ItemTypeList)
            {
                if (InventoryItem.itemType == item.itemType)
                {
                    InventoryItem.amount += item.amount;
                    itemInInventory = true;
                }
            }
            if (!itemInInventory)
            {
                ItemTypeList.Add(item);
            }
        }
        else
        {
            ItemTypeList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    public void RemoveItem(ItemTypeScript item)
    {
        if (item.IsStackable()) {
            ItemTypeScript itemInInventory = null;
            foreach (ItemTypeScript inventoryItem in ItemTypeList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount--;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null)
            {
                ItemTypeList.Add(item);
            }
        }
        else
        {
            ItemTypeList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemTypeScript> GetItemList() {
        return ItemTypeList;
    
    }
}
