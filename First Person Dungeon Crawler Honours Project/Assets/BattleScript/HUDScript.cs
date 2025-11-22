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

    public void setHUD(PlayerStats player)
    {
        playerName.text = player.Name;
        playerLevel.text = "Lvl " + player.Level;
        hpSlider.maxValue = player.MaxHP;
        hpSlider.value = player.CurrentHP;
    }
    public void setHP(int hp)
    {
        hpSlider.value = hp;
    }
}
