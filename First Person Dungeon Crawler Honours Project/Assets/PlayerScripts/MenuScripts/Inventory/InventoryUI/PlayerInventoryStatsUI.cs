using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryStatsUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;

    public Sprite ItemSprite;

    public Button UnequipWeaponBTN;
    public Button UnequipHeadBTN;
    public Button UnequipArmourBTN;
    public Button UnequipAccessoryBTN;

    [SerializeField] private EquipingItems WeaponSlot, HeadSlot, ArmourSlot, AccessorySlot;
    public ItemStats.ItemType itemtype;

    GameObject PlayerGetter;
    private InventoryScript inventroyScript;


    public ItemSlot itemSlot; 
    public TextMeshProUGUI previewNameText;
    public TextMeshProUGUI previewAttackText;
    public TextMeshProUGUI previewDefenseText;

    private void Start()
    {
        CheckStats();

        PlayerGetter = GameObject.Find("Player");
        inventroyScript = PlayerGetter.GetComponent<PlayerInventory>().inventory;
    }

    private void Update()
    {
        CheckStats();
    }

    void CheckStats()
    {
        HPText.text = DataCarryScript.instance.currHPData + " / " + DataCarryScript.instance.maxHPData;
        LVLText.text = "" + DataCarryScript.instance.levelData;
        NameText.text = "" + DataCarryScript.instance.nameData;
        AttackText.text = "" + DataCarryScript.instance.damageData;
        DefenseText.text = "" + DataCarryScript.instance.defenseData;
    }

    void PreviewStats()
    {
        previewAttackText.text = "";
        previewDefenseText.text = "";
    }

    public void Equip(GameObject ItemSlot)
    {

        ItemStats item = ItemSlot.GetComponent<ItemSlot>().Item;
        switch (item.itemType) {
            case ItemStats.ItemType.Weapon:
                WeaponSlot.EquipGear(item);
                UnequipWeaponBTN.gameObject.SetActive(true);
                break;
            case ItemStats.ItemType.Head:
                HeadSlot.EquipGear(item);
                UnequipHeadBTN.gameObject.SetActive(true);
                break;
            case ItemStats.ItemType.Armour:
                ArmourSlot.EquipGear(item);
                UnequipArmourBTN.gameObject.SetActive(true);
                break;
            case ItemStats.ItemType.Accessory:
                AccessorySlot.EquipGear(item);
                UnequipAccessoryBTN.gameObject.SetActive(true);
                break;
            case ItemStats.ItemType.HealthItem:
                UseHealingItem(item);
                break;
        }
        StatsChangePlus(item);
        inventroyScript.RemoveItem(item);
    }

    public void StatsChangePlus(ItemStats item)
    {
        DataCarryScript.instance.damageData += item.Damage;
        DataCarryScript.instance.defenseData += item.Defense;

    }

    public void StatsChangeMinus(ItemStats item)
    {
        DataCarryScript.instance.damageData -= item.Damage;
        DataCarryScript.instance.defenseData -= item.Defense;

    }

    public void UnEquip(GameObject ItemSlot)
    {
        ItemStats item = ItemSlot.GetComponent<ItemSlot>().Item;
        switch (itemtype)
        {
            case ItemStats.ItemType.Weapon:
                WeaponSlot.RemoveGear(item);
                break;
            case ItemStats.ItemType.Head:
                HeadSlot.RemoveGear(item);
                break;
            case ItemStats.ItemType.Armour:
                ArmourSlot.RemoveGear(item);
                break;
            case ItemStats.ItemType.Accessory:
                AccessorySlot.RemoveGear(item);
                break;
        }
        StatsChangeMinus(item);
        inventroyScript.AddItem(item);
        item.amount += 1;
        

    }


    public void UseHealingItem(ItemStats item)
    {
        if (DataCarryScript.instance.currHPData < DataCarryScript.instance.maxHPData)
        {
            DataCarryScript.instance.currHPData += item.Healing;
            if (DataCarryScript.instance.currHPData > DataCarryScript.instance.maxHPData)
            {
                DataCarryScript.instance.currHPData = DataCarryScript.instance.maxHPData;
            }
        }
    }

}
