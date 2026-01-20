using TMPro;
using UnityEngine;

public class PlayerLookUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;
    public bool UIVisable;
    private Transform HUDCanvas;

    private void Awake()
    {
        CheckHealth();
        CheckLevel();
        CheckName();
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
        
        HPText.text = DataCarryScript.instance.currHPData+ " / " + DataCarryScript.instance.maxHPData;
    }
    void CheckLevel()
    {
        PlayerStats levelStats = GetComponent<PlayerStats>();
        LVLText.text = "" + DataCarryScript.instance.levelData;
    }
    void CheckName()
    {
        PlayerStats levelStats = GetComponent<PlayerStats>();
        NameText.text = "" + DataCarryScript.instance.nameData;
    }


}
