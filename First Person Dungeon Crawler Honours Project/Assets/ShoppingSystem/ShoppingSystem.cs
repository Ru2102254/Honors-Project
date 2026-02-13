using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoppingSystem : MonoBehaviour
{

    [SerializeField] private InventroyUI uiInventory;
    public GameObject PlayerGetter;
    public InventoryScript MainInventory;
    public TextMeshProUGUI ShoppingText;
    public HUDScript playerHUD;


    private InventoryScript inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        MainInventory = PlayerGetter.GetComponent<PlayerInventory>().inventory;
        inventory = new InventoryScript();
        uiInventory.SetInventory(inventory);
        playerHUD.setHUD();
    }


    public void LeaveShop()
    {
        SceneManager.UnloadSceneAsync("Shopping");
        DataCarryScript.instance.movementDisabled = false;
        DataCarryScript.instance.inbattleData = false;
    }


    public void Buyitem(GameObject ItemSlot)
    {
        ItemStats item = ItemSlot.GetComponent<ItemSlot>().Item;
        if (item.ItemCost <= DataCarryScript.instance.currMoneydata)
        {
            inventory.AddItem(item);
            DataCarryScript.instance.currMoneydata -= item.ItemCost;
        }

    }
}
