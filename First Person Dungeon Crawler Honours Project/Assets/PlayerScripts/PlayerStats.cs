using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string Name;
    public int MaxHP;
    public int CurrentHP;
    public int Level;
    public int Damage;
    public int expToNext;
    public int currEXP;
    public int currMoney;
    int carryEXP;
    

    public static PlayerStats instance;


    private void Update()
    {
        MaxHP = DataCarryScript.instance.maxHPData;
        CurrentHP = DataCarryScript.instance.currHPData;
        Level = DataCarryScript.instance.levelData;
        Damage = DataCarryScript.instance.damageData;
        expToNext = DataCarryScript.instance.expToNextData;
        currEXP = DataCarryScript.instance.currEXPData;
        currMoney = DataCarryScript.instance.currMoneydata;
    }
    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;
        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }

    public bool gainEXP(int exp)
    {
        currEXP += exp;
        if (currEXP >= expToNext) {
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
        int increaseToNext = 20;
        int MaxHealthIncrease = 10;
        currEXP = extraEXP;
        Level += 1;
        expToNext += increaseToNext;
        DataCarryScript.instance.MaxHPData += MaxHealthIncrease;
        DataCarryScript.instance.currHPData = DataCarryScript.instance.MaxHPData;
    }
}
