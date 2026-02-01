using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class InventroyUI : MonoBehaviour
{
    private InventoryScript inventory;
    private Transform InventoryCanvas;
    private Transform ItemSlotContainer;
    private Transform ItemSlotTemplate;

    private void Awake()
    {
        InventoryCanvas = transform.Find("InventoryCanvas");
        ItemSlotContainer = InventoryCanvas.Find("ItemContainer");
        ItemSlotTemplate = ItemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(InventoryScript inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void AddItemFunct(int itemTypeInt)
    {
        switch (itemTypeInt)
        {
            case 1:
                inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });
                return;
            case 2:
                return;
            case 3:
                return;
        }
    }
    public void RemoveItemFunct(GameObject ItemRemove)
    {
      Destroy(ItemRemove);
        
    }
   

    private void RefreshInventoryItems() {
        int x = 0;
        int y = 0;
        float itemCellSize = 30f;
        int limitX = 4;
        //int limitY = 4;

        foreach (ItemTypeScript item in inventory.GetItemList()) {
            RectTransform itemSlotTransform =  Instantiate(ItemSlotTemplate, ItemSlotContainer).GetComponent<RectTransform>(); 
            itemSlotTransform.gameObject.SetActive(true);

            

            itemSlotTransform.anchoredPosition = new Vector2(x * itemCellSize, y * itemCellSize);
            //Image image = itemSlotTransform.Find("image").GetComponent<Image>();
            //image.sprite = item.GetSprite();
            TextMeshProUGUI itemName = itemSlotTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            itemName.SetText(item.itemType.ToString());
            TextMeshProUGUI itemAmount = itemSlotTransform.Find("Amount").GetComponent<TextMeshProUGUI>();

            if (item.amount > 1) {
                itemAmount.SetText(item.amount.ToString());
            } else {
                itemAmount.SetText("");
            
            }
                x++;
            if (x > limitX)
            {
                x = 0;
                y++;
            }
 
        }
    }
}
