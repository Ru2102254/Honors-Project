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
