using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class EquipingItems : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotName;

    [SerializeField] private ItemStats.ItemType itemType = new ItemStats.ItemType();

    private Sprite itemSprite;
    private string ItemName;

    private bool SlotInUse;

    public void EquipGear(ItemStats item)
    {
        //UpdateImage
        this.itemSprite = item.GetSprite();
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        this.ItemName = item.name;
        SlotInUse = true;
    }

    public void RemoveGear(ItemStats item)
    {
        //UpdateImage
        Destroy(this.itemSprite);
        slotName.enabled = false;

        this.ItemName = "";
        SlotInUse = false;
    }
}
