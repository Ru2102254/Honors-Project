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
    public TextMeshProUGUI playerLocation;
    public Slider hpSlider;

    public void setHUD()
    {
        playerName.text = DataCarryScript.instance.nameData;
        playerLevel.text = "Lvl " + DataCarryScript.instance.levelData;
        hpSlider.maxValue = DataCarryScript.instance.maxHPData;
        hpSlider.value = DataCarryScript.instance.currHPData;
        playerLocation.text = DataCarryScript.instance.locationData;
    }
    public void setHP(int hp)
    {
        hpSlider.value = hp;
    }
}
