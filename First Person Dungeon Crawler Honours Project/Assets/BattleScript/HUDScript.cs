using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLevel;
    public Slider hpSlider;
    int carryEXP;
    int increaseToNext = 100;


    public void setHUD()
    {
        playerName.text = DataCarryScript.instance.nameData;
        playerLevel.text = "Lvl " + DataCarryScript.instance.levelData;
        hpSlider.maxValue = DataCarryScript.instance.maxHPData;
        hpSlider.value = DataCarryScript.instance.currHPData;
    }
    public void setHP(int hp)
    {
        hpSlider.value = hp;
    }

    public bool gainEXP(int exp)
    {
        DataCarryScript.instance.currEXPData += exp;
        if (DataCarryScript.instance.currEXPData >= DataCarryScript.instance.expToNextData)
        {
            carryEXP = DataCarryScript.instance.currEXPData - DataCarryScript.instance.expToNextData;
            LevelUp(carryEXP);
            return true;
        }
        else
        {
            return false;
        }

    }

    void LevelUp(int extraEXP)
    {
        DataCarryScript.instance.currEXPData = extraEXP;
        DataCarryScript.instance.levelData += 1;
        DataCarryScript.instance.expToNextData += increaseToNext;
        DataCarryScript.instance.damageData += 2;
        DataCarryScript.instance.defenseData += 3;
    }
}
