using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventroyUI uiInventory;
    public GameObject PlayerGetter;
    public InventoryScript MainInventory;

    public InventoryScript inventory;
    private void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        MainInventory = PlayerGetter.GetComponent<PlayerInventory>().inventory;
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }

    public void AddItemFunct(int itemTypeInt)
    {
        switch (itemTypeInt)
        {
            case 0:
                inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.Weapon, amount = 1 });
                return;
            case 2:
                return;
            case 3:
                return;
        }
    }
    public void RemoveItemFunct()
    {

        inventory.RemoveItem(new ItemStats { itemType = ItemStats.ItemType.Weapon, amount = 1 });

    }

    public void RemoveFromPlayer()
    {
        MainInventory.RemoveItem(new ItemStats { itemType = ItemStats.ItemType.Weapon, amount = 1 });
    }
}
