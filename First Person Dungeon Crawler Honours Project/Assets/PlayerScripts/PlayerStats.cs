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

    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;
        if (CurrentHP <= 0) 
            return true;
        else
            return false;
    }

}
