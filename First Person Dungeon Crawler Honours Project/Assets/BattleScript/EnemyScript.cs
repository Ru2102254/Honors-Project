using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Sprite eSprite;
    public string eName;
    public int eMaxHP;
    public int eCurrentHP;
    public int eLevel;
    public int eDamage;
    public int expDrop;
    public int MoneyDrop;

    public bool TakeDamage(int dmg)
    {
        eCurrentHP -= dmg;
        if (eCurrentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }
}
