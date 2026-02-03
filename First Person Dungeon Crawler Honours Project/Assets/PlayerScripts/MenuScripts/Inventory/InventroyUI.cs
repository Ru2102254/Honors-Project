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
    private Transform EquipmentCanvas;
    public RectTransform EquipmentHolder;
    public RectTransform EquipmentPanel;
    public RectTransform EquipmentSlotTemplate;
    public TextMeshProUGUI ItemAmount;
    public TextMeshProUGUI ItemName;

    private void Awake()
    {
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

        foreach (Transform child in EquipmentPanel)
        {
            if (child == EquipmentSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        int x = 0;
        int y = 0;
        float itemCellSize = 30f;
        int limitX = 4;
        //int limitY = 4;

        foreach (ItemTypeScript item in inventory.GetItemList()) {
            RectTransform itemSlotTransform =  Instantiate(EquipmentSlotTemplate, EquipmentPanel).GetComponent<RectTransform>(); 
            itemSlotTransform.gameObject.SetActive(true);


            itemSlotTransform.anchoredPosition = new Vector2(x * itemCellSize, y * itemCellSize);
            //Image image = itemSlotTransform.Find("image").GetComponent<Image>();
            //image.sprite = item.GetSprite();

            ItemName.SetText(item.itemType.ToString());

            if (item.amount > 1) {
                ItemAmount.SetText(item.amount.ToString());
            } else {
                ItemAmount.SetText("");
            
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
