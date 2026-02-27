using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseCustomise : MonoBehaviour
{
    public GameObject PlayerInfo;
    public TextMeshProUGUI PlayerNameTXT;
    public GameObject PlayerImage;

    public GameObject MapPanel;

    public GameObject PauseStats;
    public TextMeshProUGUI HPTXT;
    public TextMeshProUGUI LevelTXT;
    public TextMeshProUGUI MoneyTXT;
    public TextMeshProUGUI KeysTXT;

    public GameObject Map;
    public TextMeshProUGUI MapTXT;
    public GameObject BTN_Resume;
    public GameObject BTN_Equipemnt;
    public GameObject BTN_System;
    public void SetColour(int colourOptionPicked)
    {
        switch (colourOptionPicked)
        {
            case 0:
                PlayerNameTXT.GetComponent<Image>().color = Color.red;
                PlayerImage.GetComponent<Image>().color = Color.red;
                HPTXT.GetComponent<Image>().color = Color.red;
                LevelTXT.GetComponent<Image>().color = Color.red;
                MoneyTXT.GetComponent<Image>().color = Color.red;
                KeysTXT.GetComponent<Image>().color = Color.red;
                break;

        }
    }

}
