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
        CheckStats();
    }

    private void Update()
    {
        CheckStats();
    }
    void CheckStats()
    {
        HPText.text = DataCarryScript.instance.currHPData + " / " + DataCarryScript.instance.maxHPData;
        LVLText.text = "" + DataCarryScript.instance.levelData;
        NameText.text = "" + DataCarryScript.instance.nameData;
        LocationText.text = "" + DataCarryScript.instance.locationData;
        MoneyText.text = "Money: " + DataCarryScript.instance.CurrMoneyData;
    }
}
