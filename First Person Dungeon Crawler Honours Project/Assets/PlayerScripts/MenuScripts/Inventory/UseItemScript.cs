using UnityEngine;

public class UseItemScript : MonoBehaviour
{
    public ItemStats UsedItem;

    public void UseHealingItem(ItemStats UsedItem)
    {
        if (DataCarryScript.instance.currHPData < DataCarryScript.instance.maxHPData)
        {
            DataCarryScript.instance.currHPData += UsedItem.Healing;
            if (DataCarryScript.instance.currHPData > DataCarryScript.instance.maxHPData)
            {
                DataCarryScript.instance.currHPData = DataCarryScript.instance.maxHPData;
            }
        }
    }
}
