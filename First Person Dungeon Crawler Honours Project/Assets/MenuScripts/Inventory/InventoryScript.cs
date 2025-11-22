using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    private List<ItemTypeScript> ItemTypeList;

    public InventoryScript()
    {
        ItemTypeList = new List<ItemTypeScript>();
    }

    public void AddItem(ItemTypeScript item)
    {
        ItemTypeList.Add(item);
    }
}
