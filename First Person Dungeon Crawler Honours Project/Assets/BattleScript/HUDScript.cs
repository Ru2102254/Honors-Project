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
    int currEXP = DataCarryScript.instance.currEXPData;
    int expToNext = DataCarryScript.instance.expToNextData;
    int Level = DataCarryScript.instance.levelData;
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
        currEXP += exp;
        if (currEXP >= expToNext)
        {
            carryEXP = currEXP - expToNext;
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
        currEXP = extraEXP;
        Level += 1;
        expToNext += increaseToNext;
    }
}
