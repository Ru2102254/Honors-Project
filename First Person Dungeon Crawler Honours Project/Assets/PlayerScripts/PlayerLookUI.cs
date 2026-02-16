using TMPro;
using UnityEngine;

public class PlayerLookUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LocationText;
    public TextMeshProUGUI KeysText;
    public bool UIVisable;
    private Transform HUDCanvas;

    private void Start()
    {
        CheckStats();
        HUDCanvas = transform.Find("PlayerHUD/PlayerHUDCanvas");
        if (UIVisable)
        {
           HUDCanvas.gameObject.SetActive(true);
        }
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
        KeysText.text = "" + DataCarryScript.instance.keysData;
    }


}
