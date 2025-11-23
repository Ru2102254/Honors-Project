using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

using TMPro;
using UnityEditor.UI;

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
