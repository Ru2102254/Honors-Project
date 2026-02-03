using TMPro;
using UnityEngine;

public class ShoppingSystem : MonoBehaviour
{

    [SerializeField] private InventroyUI uiInventory;
    public GameObject PlayerGetter;
    public InventoryScript MainInventory;
    public TextMeshProUGUI ShoppingText;

    private InventoryScript inventory;
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
        int cost = 0;
        switch (ItemType) {
            case 0:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Weapon, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;
            case 1:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Armour, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;
            case 2:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.Accessory, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;
            case 3:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.HealthItem, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;
            case 4:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.HealthItemMore, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;
            case 5:
                if (cost <= DataCarryScript.instance.currMoneydata)
                {
                    inventory.AddItem(new ItemTypeScript { itemType = ItemTypeScript.ItemType.HealthItemMost, amount = 1 });
                    DataCarryScript.instance.currMoneydata -= cost;
                }
                break;

        }

    }
}
