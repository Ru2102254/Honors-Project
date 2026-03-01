using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudCusomisation : MonoBehaviour
{
    public GameObject PlayerInfo;
    public TextMeshProUGUI PlayerNameTXT;
    public GameObject PlayerImage;

    public GameObject MiniMapPanel;

    public GameObject LocationPanel;
    public TextMeshProUGUI LocationTXT;

    public GameObject HUDStats;
    public GameObject HUDHPPanel;
    public TextMeshProUGUI HPTXT;
    public TextMeshProUGUI HPNumTXT;
    public GameObject HUDLevelPanel;
    public TextMeshProUGUI LevelTXT;
    public TextMeshProUGUI LevelNumTXT;
    public GameObject HUDKeysPanel;
    public TextMeshProUGUI KeysTXT;
    public TextMeshProUGUI KeysNumTXT;

    public Material colourChangeMaterial;

    public int PanelType;


    Vector3 playerInfoScale = new Vector3(1, 1, 1);
    Vector3 miniMapScale = new Vector3(1, 1, 1);
    Vector3 locationScale = new Vector3(1, 1, 1);
    Vector3 statsScale = new Vector3(1, 1, 1);

    Vector3 playerInfoPos = new Vector3(100, 159, 0);
    Vector3 miniMapPos = new Vector3(970, 159, 0);
    Vector3 locationPos = new Vector3(970, 590, 0);
    Vector3 statsPos = new Vector3(90, -73, 0);

    Vector3 BaseplayerInfoPos = new Vector3(100, 159, 0);
    Vector3 BaseminiMapPos = new Vector3(970, 159, 0);
    Vector3 BaselocationPos = new Vector3(970, 590, 0);
    Vector3 BasestatsPos = new Vector3(100, 590, 0);

    float defaultTextSize = 25;
    float defaultScale = 1;


    public void SetPanelType(int NewPanelType)
    {
        PanelType = NewPanelType;
    }

    public void SetTextSize(float textSize)
    {
        PlayerNameTXT.fontSize = textSize;
        LocationTXT.fontSize = textSize;
        HPTXT.fontSize = textSize;
        HPNumTXT.fontSize = textSize;
        LevelTXT.fontSize = textSize;
        LevelNumTXT.fontSize = textSize;
        KeysTXT.fontSize = textSize;
        KeysNumTXT.fontSize = textSize;
    }

    public void PanelWidth(float buttonSize)
    {
        switch (PanelType)
        {
            case 0:
                playerInfoScale.x = buttonSize;
                PlayerInfo.transform.localScale = playerInfoScale;
                break;
            case 1:
                miniMapScale.x = buttonSize;
                MiniMapPanel.transform.localScale = miniMapScale;
                break;
            case 2:
                locationScale.x = buttonSize;
                LocationPanel.transform.localScale = locationScale;
                break;
            case 3:
                statsScale.x = buttonSize;
                HUDStats.transform.localScale = statsScale;
                break;
        }

    }

    public void PanelHeight(float buttonSize)
    {
        switch (PanelType)
        {
            case 0:
                playerInfoScale.y = buttonSize;
                PlayerInfo.transform.localScale = playerInfoScale;
                break;
            case 1:
                miniMapScale.y = buttonSize;
                MiniMapPanel.transform.localScale = miniMapScale;
                break;
            case 2:
                locationScale.y = buttonSize;
                LocationPanel.transform.localScale = locationScale;
                break;
            case 3:
                statsScale.y = buttonSize;
                HUDStats.transform.localScale = statsScale;
                break;
        }
    }

    public void SetPanelX(float buttonPos)
    {
        switch (PanelType)
        {
            case 0:
                playerInfoPos.x = buttonPos;
                PlayerInfo.transform.position = playerInfoPos;
                break;
            case 1:
                miniMapPos.x = buttonPos;
                MiniMapPanel.transform.position = miniMapPos;
                break;
            case 2:
                locationPos.x = buttonPos;
                LocationPanel.transform.position = locationPos;
                break;
            case 3:
                statsPos.x = buttonPos;
                HUDStats.transform.position = statsPos;
                break;
        }
    }
    public void SetPanelY(float buttonPos)
    {
        switch (PanelType)
        {
            case 0:
                playerInfoPos.y = buttonPos;
                PlayerInfo.transform.position = playerInfoPos;
                break;
            case 1:
                miniMapPos.y = buttonPos;
                MiniMapPanel.transform.position = miniMapPos;
                break;
            case 2:
                locationPos.y = buttonPos;
                LocationPanel.transform.position = locationPos;
                break;
            case 3:
                statsPos.y = buttonPos;
                HUDStats.transform.position = statsPos;
                break;
        }
    }

    public void ResetTextSize()
    {
        SetTextSize(defaultTextSize);
    }

    public void ResetPanelSize()
    {
        PanelWidth(defaultScale);
        PanelWidth(defaultScale);
    }

    public void ResetPanelLocation()
    {

        switch (PanelType)
        {
            case 0:
                SetPanelX(BaseplayerInfoPos.x);
                SetPanelY(BaseplayerInfoPos.y);
                break;
            case 1:
                SetPanelX(BaseminiMapPos.x);
                SetPanelY(BaseminiMapPos.y);
                break;
            case 2:
                SetPanelX(BaselocationPos.x);
                SetPanelY(BaselocationPos.y);
                break;
            case 3:
                SetPanelX(BasestatsPos.x);
                SetPanelY(BasestatsPos.y);
                break;
        }
    }






    public void SetColour(int colourOptionPicked)
    {
        switch (colourOptionPicked)
        {
            case 0:
                colourChangeMaterial.SetColor("_NewColour", Color.red);
                break;

        }
    }

}
