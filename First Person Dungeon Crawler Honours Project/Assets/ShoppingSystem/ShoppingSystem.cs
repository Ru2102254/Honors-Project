using TMPro;
using UnityEngine;

public class ShoppingSystem : MonoBehaviour
{

    [SerializeField] private InventroyUI uiInventory;
    public GameObject PlayerGetter;
    public InventoryScript MainInventory;
    public TextMeshProUGUI ShoppingText;

    private InventoryScript inventory;


    public ItemStats HealthItem;
    public ItemStats WeaponItem;
    public ItemStats ArmourItem;
    public ItemStats AccessoryItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        MainInventory = PlayerGetter.GetComponent<PlayerInventory>().inventory;
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buyitem(int ItemType)
    {
        switch (ItemType) {
            case 0:
                if (WeaponItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.Weapon, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= WeaponItem.ItemCost;
                }
                break;
            case 1:
                if (ArmourItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.Armour, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= ArmourItem.ItemCost;
                }
                break;
            case 2:
                if (AccessoryItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.Accessory, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= AccessoryItem.ItemCost;
                }
                break;
            case 3:
                if (HealthItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.HealthItem, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= HealthItem.ItemCost;
                }
                break;
            case 4:
                if (HealthItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    //inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.HealthItemMore, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= HealthItem.ItemCost;
                }
                break;
            case 5:
                if (HealthItem.ItemCost <= DataCarryScript.instance.currMoneydata)
                {
                    //inventory.AddItem(new ItemStats { itemType = ItemStats.ItemType.HealthItemMost, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= HealthItem.ItemCost;
                }
                break;

        }

    }
}
