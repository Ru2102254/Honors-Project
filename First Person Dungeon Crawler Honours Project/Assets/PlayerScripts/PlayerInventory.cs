using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventroyUI uiInventory;

    private InventoryScript inventory;
    private void Awake()
    {
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }
    
}
