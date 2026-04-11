using System;
using System.Collections;
using UnityEngine;

public class TestSceneScript : MonoBehaviour
{

    public GameObject PlayerGetter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerGetter = GameObject.Find("Player");
        DataCarryScript.instance.maxHPData = 40;
        DataCarryScript.instance.currHPData = 40;
        DataCarryScript.instance.levelData = 1;
        DataCarryScript.instance.damageData = 10;
        DataCarryScript.instance.defenseData = 0;
        StartCoroutine(ResetPos());
        DataCarryScript.instance.inbattleData = false;

        //PlayerGetter.GetComponent<PlayerInventory>().inventory.GetItemList().Clear();
        
    }

    IEnumerator ResetPos()
    {
        DataCarryScript.instance.movementDisabled = true;
        yield return new WaitForSeconds(0.1f);
        DataCarryScript.instance.PlayerPositionData = new Vector3(0, 1, -6);
        PlayerGetter.transform.rotation = new Quaternion(0, 0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        DataCarryScript.instance.movementDisabled = false;
    }

    
}
