using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventroyUI uiInventory;
    public GameObject PlayerGetter;
    public InventoryScript MainInventory;

    public InventoryScript inventory;

    ItemStats Item;

    GameObject InventoryGetter;
    GameObject EquipmentCanvasGetter;
    private void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        MainInventory = PlayerGetter.GetComponent<PlayerInventory>().inventory;
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }


    public void OpenEquipmentMenu()
    {
        InventoryGetter = GameObject.Find("InventoryMenu");
        EquipmentCanvasGetter = InventoryGetter.transform.GetChild(0).gameObject;
        EquipmentCanvasGetter.gameObject.SetActive(true);
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
