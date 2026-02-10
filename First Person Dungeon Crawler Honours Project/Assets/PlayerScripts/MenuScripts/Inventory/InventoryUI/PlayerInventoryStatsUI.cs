using TMPro;
using UnityEngine;

public class PlayerInventoryStatsUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;

    public Sprite ItemSprite;



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

    }

    void CheckStats()
    {
        HPText.text = DataCarryScript.instance.currHPData + " / " + DataCarryScript.instance.maxHPData;
        LVLText.text = "" + DataCarryScript.instance.levelData;
        NameText.text = "" + DataCarryScript.instance.nameData;
        AttackText.text = "" + DataCarryScript.instance.damageData;
        DefenseText.text = "" + DataCarryScript.instance.CurrMoneyData;
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
                break;
            case ItemStats.ItemType.Head:
                HeadSlot.EquipGear(item);
                break;
            case ItemStats.ItemType.Armour:
                ArmourSlot.EquipGear(item);
                break;
            case ItemStats.ItemType.Accessory:
                AccessorySlot.EquipGear(item);
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
        ItemStats item = ItemSlot.GetComponent<ItemStats>();
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
        inventroyScript.AddItem(item);
    }


}
