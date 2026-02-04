using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    public event EventHandler OnItemListChanged;
    private List<ItemStats> ItemStatsList;

    public InventoryScript()
    {
        ItemStatsList = new List<ItemStats>();

        AddItem(ScriptableObject.CreateInstance<ItemStats>());
        Debug.Log(ItemStatsList.Count);
    }

    public void AddItem(ItemStats item)
    {
        if (item.IsStackable())
        {
            bool itemInInventory = false;
            foreach (ItemStats InventoryItem in ItemStatsList)
            {
                if (InventoryItem.itemType == item.itemType)
                {
                    InventoryItem.amount += item.amount;
                    itemInInventory = true;
                }
            }
            if (!itemInInventory)
            {
                ItemStatsList.Add(item);
            }
        }
        else
        {
            ItemStatsList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    public void RemoveItem(ItemStats item)
    {
        if (item.IsStackable()) {
            ItemStats itemInInventory = null;
            foreach (ItemStats inventoryItem in ItemStatsList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <=0)
            {
                ItemStatsList.Remove(itemInInventory);
            }
        }
        else
        {
            ItemStatsList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemStats> GetItemList() {
        return ItemStatsList;
    
    }
}
