using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventroyUI : MonoBehaviour
{
    private InventoryScript inventory;
    public RectTransform EquipmentPanel;
    public RectTransform EquipmentSlotTemplate;

    public ItemSlot itemSlot;


    private void Start()
    {
    //    EquipmentCanvas = transform.Find("EquipmentCanvas");
    //    EquipmentHolder = GameObject.Find("EquipmentHolder");
    //    EquipmentPanel = GameObject.Find("EquipmentPanel");
    //    EquipmentSlotTemplate = GameObject.Find("EquipmentSlotTemplate");

    }

    public void SetInventory(InventoryScript inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventoryChanged;
        RefreshInventoryItems();
    }

    private void InventoryChanged(object sender, System.EventArgs e)
    { 
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {

        foreach (RectTransform child in EquipmentPanel)
        {
            if (child == EquipmentSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        int x = 0;
        int y = 0;
        float itemCellSize = 30f;
        int limitX = 4;
        //int limitY = 4;

        foreach (ItemStats item in inventory.GetItemList()) {
            RectTransform itemSlotTransform =  Instantiate(EquipmentSlotTemplate, EquipmentPanel.transform).GetComponent<RectTransform>();
            itemSlotTransform.gameObject.SetActive(true);

            itemSlot = itemSlotTransform.GetComponent<ItemSlot>();
            itemSlot.Item = item;
            itemSlotTransform.anchoredPosition = new Vector2(x * itemCellSize, y * itemCellSize);
            Image ImageSlot = itemSlotTransform.Find("Image").GetComponent<Image>();
            ImageSlot.sprite = item.ItemImage;
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
