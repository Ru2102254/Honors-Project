using TMPro;
using UnityEngine;

public class PlayerPauseUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LocationText;
    public TextMeshProUGUI MoneyText;

    private void Start()
    {
        CheckHealth();
        CheckLevel();
        CheckName();
        CheckLocation();
        CheckMoney();
    }

    private void Update()
    {

    }

    void CheckHealth()
    {
        HPText.text = DataCarryScript.instance.currHPData + " / " + DataCarryScript.instance.maxHPData;
    }
    void CheckLevel()
    {
        LVLText.text = "Level: " + DataCarryScript.instance.levelData;
    }
    void CheckName()
    {
        NameText.text = "" + DataCarryScript.instance.nameData;
    }

    void CheckLocation()
    {
        LocationText.text = "" + DataCarryScript.instance.locationData;
    }
    void CheckMoney()
    {
        MoneyText.text = "Money: " + DataCarryScript.instance.CurrMoneyData;
    }
}
