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
    public string ItemName, ItemDescription;



    [SerializeField] private EquipingItems WeaponSlot, HeadSlot, ArmourSlot, AccessorySlot;
    public ItemStats.ItemType itemtype;

    GameObject PlayerGetter;
    private InventoryScript inventroyScript;

    private void Start()
    {
        CheckHealth();
        CheckLevel();
        CheckName();
        CheckAttack();
        CheckDefense();

        PlayerGetter = GameObject.Find("Player");
        inventroyScript = PlayerGetter.GetComponent<PlayerInventory>().inventory;
    }

    private void Update()
    {

    }

    void CheckHealth()
    {
        HPText.text = DataCarryScript.instance.currHPData + " / " + DataCarryScript.instance.maxHPData;
    }
    void CheckLevel()
    {
        LVLText.text = "" + DataCarryScript.instance.levelData;
    }
    void CheckName()
    {
        NameText.text = "" + DataCarryScript.instance.nameData;
    }

    void CheckAttack()
    {
        AttackText.text = "" + DataCarryScript.instance.damageData;
    }
    void CheckDefense()
    {
        DefenseText.text = "" + DataCarryScript.instance.CurrMoneyData;
    }

    public void Equip(GameObject ItemSlot)
    {

        ItemStats item = ItemSlot.GetComponent<ItemStats>();
        switch (itemtype) {
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
        inventroyScript.RemoveItem(item);
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
