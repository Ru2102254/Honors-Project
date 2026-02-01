using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventroyUI uiInventory;

    private InventoryScript inventory;
    private void Start()
    {
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }

    public void AddItemFunct(int itemTypeInt)
    {
        switch (itemTypeInt)
        {
            case 0:
                inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });
                return;
            case 2:
                return;
            case 3:
                return;
        }
    }
    public void RemoveItemFunct()
    {

        inventory.RemoveItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });

    }
}
