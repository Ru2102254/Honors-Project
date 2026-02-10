using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class EquipingItems : MonoBehaviour
{
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemStats.ItemType itemType = new ItemStats.ItemType();

    private Sprite itemSprite;
    private string ItemName;

    public int damage;
    public int defense;

    private bool SlotInUse;

    private EquipmentSO equipmentSO;
    public DataCarryScript dataManager;

    private void Start()
    {
        equipmentSO = GameObject.Find("EquimentCanvas").GetComponent<EquipmentSO>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataCarryScript>();
    }

    public void EquipGear(ItemStats item)
    {
        //UpdateImage
        this.itemSprite = item.ItemImage;
        slotImage.sprite = this.itemSprite;

        this.ItemName = item.name;
        SlotInUse = true;

        this.damage = item.Damage;
        this.defense = item.Defense;
        for (int i = 0; i < equipmentSO.equipmentSO.Length; i++)
        {
            if (equipmentSO.equipmentSO[i].name == this.name)
            {
                equipmentSO.equipmentSO[i].EquipItem(item);
                EquipItem(item);
            }
        }
    }


    public void EquipItem(ItemStats item)
    {
        dataManager.Damagedata += item.Damage;
        dataManager.DefenseData += item.Defense;
    }

    public void UnEquipItem(ItemStats item)
    {
        dataManager.damageData -= item.Damage;
        dataManager.DefenseData -= item.Defense;
    }


    public void RemoveGear(ItemStats item)
    {
        //UpdateImage
        Destroy(this.itemSprite);

        this.ItemName = "";
        SlotInUse = false;

        for (int i = 0; i < equipmentSO.equipmentSO.Length; i++)
        {
            if (equipmentSO.equipmentSO[i].name == this.name)
            {
                equipmentSO.equipmentSO[i].UnEquipItem(item);
            }
        }
    }


    public void PreviewEquipment()
    {

    }
}
