using TMPro;
using UnityEngine;

public class PlayerInventoryStatsUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;

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
        LVLText.text = "" + DataCarryScript.instance.levelData;
    }
    void CheckName()
    {
        NameText.text = "" + DataCarryScript.instance.nameData;
    }

    void CheckLocation()
    {
        AttackText.text = "" + DataCarryScript.instance.damageData;
    }
    void CheckMoney()
    {
        DefenseText.text = "" + DataCarryScript.instance.CurrMoneyData;
    }
}
