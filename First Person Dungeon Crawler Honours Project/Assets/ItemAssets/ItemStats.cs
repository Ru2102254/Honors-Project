using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/ItemStats")]
public class ItemStats : ScriptableObject
{

    public enum ItemType { Weapon, Head, Armour, Accessory, HealthItem }

    public ItemType itemType;

    public string ItemName;
    public int amount, ItemCost, Damage, Defense, Healing;

    public void EquipItem()
    {
        DataCarryScript.instance.damageData += Damage;
        DataCarryScript.instance.DefenseData += Defense;
    }

    public void UnEquipItem()
    {
        DataCarryScript.instance.damageData -= Damage;
        DataCarryScript.instance.DefenseData -= Defense;
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon: return ItemAssets.Instance.weaponSprite;
            case ItemType.Head: return ItemAssets.Instance.headSprite;
            case ItemType.Armour: return ItemAssets.Instance.armourSprite;
            case ItemType.Accessory: return ItemAssets.Instance.acessorySpreite;
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

