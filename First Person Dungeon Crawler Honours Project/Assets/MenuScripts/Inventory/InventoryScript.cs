using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    private List<ItemTypeScript> ItemTypeList;

    public InventoryScript()
    {
        ItemTypeList = new List<ItemTypeScript>();

        AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });
        Debug.Log(ItemTypeList.Count);
    }

    public void AddItem(ItemTypeScript item)
    {
        ItemTypeList.Add(item);
    }

    public List<ItemTypeScript> GetItemList() {
        return ItemTypeList;
    
    }
}
