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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetTextSize(float textSize)
    {
        FightText.fontSize += textSize;
        TalkText.fontSize += textSize; 
        ItemText.fontSize += textSize; 
        AbscondText.fontSize += textSize;
        CustomiseText.fontSize += textSize;
        DialogueText.fontSize += textSize;
        NameText.fontSize += textSize;
        LvlText.fontSize += textSize;
    }

    public void SetButtonSize(float buttonSize) {
        
        Vector3 buttonPosition = Vector3.zero;
        buttonPosition.x += buttonSize;
        ButtonPanel.transform.position += buttonPosition;
    }
}
