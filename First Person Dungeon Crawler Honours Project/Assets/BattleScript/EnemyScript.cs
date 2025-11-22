using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string eName;
    public int eMaxHP;
    public int eCurrentHP;
    public int eLevel;
    public int eDamage;

    public bool TakeDamage(int dmg)
    {
        eCurrentHP -= dmg;
        if (eCurrentHP <= 0)
            return true;
        else
            return false;
    }
}
