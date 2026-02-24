using TMPro;
using UnityEngine;

public class CustomisingUI : MonoBehaviour
{
    public TextMeshProUGUI FightText;
    public TextMeshProUGUI TalkText;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI AbscondText;
    public TextMeshProUGUI CustomiseText;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LvlText;

    public GameObject ButtonPanel;

    Vector3 buttonScale = new Vector3(1, 1, 1);
    Vector3 buttonPosition = new Vector3(330, 120, 0);
    Vector3 defaultButtonPosition = new Vector3(330, 120 , 0);

    float defaultTextSize = 20;
    float defaultButton = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetButtonTextSize(float textSize)
    {
        FightText.fontSize = textSize;
        TalkText.fontSize = textSize; 
        ItemText.fontSize = textSize; 
        AbscondText.fontSize = textSize;
        CustomiseText.fontSize = textSize;
        NameText.fontSize = textSize;
        LvlText.fontSize = textSize;
    }

    public void SetBattleTextSize(float textSize)
    {
        DialogueText.fontSize = textSize;
    }
    public void SetButtonWidth(float buttonSize) {

        buttonScale.x = buttonSize;
        ButtonPanel.transform.localScale = buttonScale;
    }
    public void SetButtonHeight(float buttonSize) {
        buttonScale.y = buttonSize;
        ButtonPanel.transform.localScale = buttonScale;
    }

    public void SetButtonX(float buttonPos) {
        buttonPosition.x = buttonPos;
        ButtonPanel.transform.position = buttonPosition;
    }
    public void SetButtonY(float buttonPos)
    {
        buttonPosition.y = buttonPos;
        ButtonPanel.transform.position = buttonPosition;
    }

    public void ResetTextSize() {
        SetButtonTextSize(defaultTextSize);
    }

    public void ResetButtonSize()
    {
        SetButtonWidth(defaultButton);
        SetButtonHeight(defaultButton);
    }

    public void ResetButtonLocation()
    {
        SetButtonX(defaultButtonPosition.x);
        SetButtonY(defaultButtonPosition.y);
    }
}
