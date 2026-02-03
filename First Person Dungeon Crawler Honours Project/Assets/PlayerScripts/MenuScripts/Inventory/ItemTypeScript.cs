using Unity.VisualScripting;
using UnityEngine;

public class ItemTypeScript
{
    public enum ItemType { Weapon, Armour, Accessory, HealthItem, HealthItemMore, HealthItemMost }

    public ItemType itemType;
    public int amount;

       
    

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon: return ItemAssets.Instance.weaponSprite;
            case ItemType.Armour: return ItemAssets.Instance.armourSprite;
            case ItemType.Accessory: return ItemAssets.Instance.acessorySpreite;
            case ItemType.HealthItem: return ItemAssets.Instance.heathItemSprite;
            case ItemType.HealthItemMore: return ItemAssets.Instance.heathItemSprite;
            case ItemType.HealthItemMost: return ItemAssets.Instance.heathItemSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon: return true;
            case ItemType.Armour: return true;
            case ItemType.Accessory: return true;
            case ItemType.HealthItem: return true;
            case ItemType.HealthItemMore: return true;
            case ItemType.HealthItemMost: return true;
        }
    }
}
