using TMPro;
using UnityEngine;

public class PlayerLookUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LocationText;
    public bool UIVisable;
    private Transform HUDCanvas;

    private void Awake()
    {
        CheckHealth();
        CheckLevel();
        CheckName();
        CheckLocation();
        HUDCanvas = transform.Find("PlayerHUD/PlayerHUDCanvas");
        if (UIVisable)
        {
           HUDCanvas.gameObject.SetActive(true);
        }
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

    void CheckLocation() {
        LocationText.text = "" + DataCarryScript.instance.locationData;
    }


}
