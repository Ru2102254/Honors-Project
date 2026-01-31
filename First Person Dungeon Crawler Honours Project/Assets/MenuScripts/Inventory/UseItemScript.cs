using UnityEngine;

public class UseItemScript : MonoBehaviour
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseHealingItem()
    {
        if (DataCarryScript.instance.currHPData < DataCarryScript.instance.maxHPData)
        {
            DataCarryScript.instance.currHPData += 10;
            if (DataCarryScript.instance.currHPData > DataCarryScript.instance.maxHPData)
            {
                DataCarryScript.instance.currHPData = DataCarryScript.instance.maxHPData;
            }
        }
    }
}
