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

    ItemStats Item;
    private void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        MainInventory = PlayerGetter.GetComponent<PlayerInventory>().inventory;
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }

    public void AddItemFunct(ItemStats Item)
    {
        inventory.AddItem(Item);
    }
    public void RemoveItemFunct()
    {

        inventory.RemoveItem(Item);

    }

    public void RemoveFromPlayer()
    {
        MainInventory.RemoveItem(Item);
    }

}
