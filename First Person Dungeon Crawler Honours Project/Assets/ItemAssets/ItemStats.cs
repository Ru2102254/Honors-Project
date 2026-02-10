using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/ItemStats")]
public class ItemStats : ScriptableObject
{

    public enum ItemType { Weapon, Head, Armour, Accessory, HealthItem, Generic }

    public ItemType itemType;

    public Sprite ItemImage;

    public string ItemName;
    public int amount, ItemCost, Damage, Defense, Healing;

    public void EquipItem(ItemStats item)
    {
       
        DataCarryScript.instance.damageData += item.Damage;
        DataCarryScript.instance.defenseData += item.Defense;
    }

    public void UnEquipItem(ItemStats item)
    {
        DataCarryScript.instance.damageData -= item.Damage;
        DataCarryScript.instance.DefenseData -= item.Defense;
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon: return ItemAssets.Instance.weaponSprite;
            case ItemType.Head: return ItemAssets.Instance.headSprite;
            case ItemType.Armour: return ItemAssets.Instance.armourSprite;
            case ItemType.Accessory: return ItemAssets.Instance.acessorySprite;
            case ItemType.HealthItem: return ItemAssets.Instance.heathItemSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon: return true;
            case ItemType.Head: return true;
            case ItemType.Armour: return true;
            case ItemType.Accessory: return true;
            case ItemType.HealthItem: return true;
        }
    }

}

