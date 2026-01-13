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
    int carryEXP;
    int increaseToNext;

    public static PlayerStats instance;

    private void Awake()
    {
        DataCarryScript.instance.nameData = Name;
        DataCarryScript.instance.maxHPData = MaxHP;
        DataCarryScript.instance.currHPData = CurrentHP;
        DataCarryScript.instance.levelData = Level;
        DataCarryScript.instance.damageData = Damage;
        DataCarryScript.instance.expToNextData = expToNext;
        DataCarryScript.instance.currEXPData = currEXP;
    }

    private void Update()
    {
        MaxHP = DataCarryScript.instance.MaxHPData;
        CurrentHP = DataCarryScript.instance.currHPData;
        Level = DataCarryScript.instance.levelData;
        Damage = DataCarryScript.instance.damageData;
        expToNext = DataCarryScript.instance.expToNextData;
        currEXP = DataCarryScript.instance.currEXPData;
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
        currEXP = extraEXP;
        Level += 1;
        expToNext += increaseToNext;
    }
}
