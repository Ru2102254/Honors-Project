using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public float newTextSize = 20;
    public float newBattleSize = 20;
    public float newButtonScaleX = 1;
    public float newButtonScaleY = 1;
    public float newButtonX = 330;
    public float newButtonY = 120;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetUI()
    {
        FightText.fontSize = newTextSize;
        TalkText.fontSize = newTextSize;
        ItemText.fontSize = newTextSize;
        AbscondText.fontSize = newTextSize;
        CustomiseText.fontSize = newTextSize;
        NameText.fontSize = newTextSize;
        LvlText.fontSize = newTextSize;

        DialogueText.fontSize = newBattleSize;

        buttonScale.x = newButtonScaleX;
        ButtonPanel.transform.localScale = buttonScale;
        buttonScale.y = newButtonScaleY;
        ButtonPanel.transform.localScale = buttonScale;

        buttonPosition.x = newButtonX;
        ButtonPanel.transform.position = buttonPosition;
        buttonPosition.x = newButtonY;
        ButtonPanel.transform.position = buttonPosition;
    }
    public void SetButtonTextSize(float textSize)
    {
        FightText.fontSize = textSize;
        TalkText.fontSize = textSize; 
        ItemText.fontSize = textSize; 
        AbscondText.fontSize = textSize;
        CustomiseText.fontSize = textSize;
        NameText.fontSize = textSize;
        LvlText.fontSize = textSize;

        newTextSize = textSize;
    }

    public void SetBattleTextSize(float textSize)
    {
        DialogueText.fontSize = textSize;

        newBattleSize = textSize;
    }
    public void SetButtonWidth(float buttonSize) {

        buttonScale.x = buttonSize;
        ButtonPanel.transform.localScale = buttonScale;

        newButtonScaleX = buttonSize;
    }
    public void SetButtonHeight(float buttonSize) {
        buttonScale.y = buttonSize;
        ButtonPanel.transform.localScale = buttonScale;
        newButtonScaleY = buttonSize;
    }

    public void SetButtonX(float buttonPos) {
        buttonPosition.x = buttonPos;
        ButtonPanel.transform.position = buttonPosition;
        newButtonX = buttonPos;
    }
    public void SetButtonY(float buttonPos)
    {
        buttonPosition.y = buttonPos;
        ButtonPanel.transform.position = buttonPosition;
        newButtonY = buttonPos;
    }

    public void ResetTextSize() {
        SetButtonTextSize(defaultTextSize);
    }

    public void SetColour(int colourOptionPicked)
    {
        switch (colourOptionPicked) {
            case 0:
                ButtonPanel.GetComponent<Image>().color = Color.red;
                break;

        }
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
