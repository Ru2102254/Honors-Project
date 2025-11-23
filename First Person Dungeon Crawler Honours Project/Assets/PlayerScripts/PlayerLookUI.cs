using TMPro;
using UnityEngine;

public class PlayerLookUI : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI LVLText;
    public TextMeshProUGUI NameText;

    private void Awake()
    {
        CheckHealth();
        CheckLevel();
        CheckName();
    }

    private void Update()
    {
        
    }

    void CheckHealth()
    {
        PlayerStats playerStats = GetComponent<PlayerStats>();
        HPText.text = playerStats.CurrentHP + " / " + playerStats.MaxHP;
    }
    void CheckLevel()
    {
        PlayerStats levelStats = GetComponent<PlayerStats>();
        LVLText.text = "" + levelStats.Level;
    }
    void CheckName()
    {
        PlayerStats levelStats = GetComponent<PlayerStats>();
        NameText.text = "" + levelStats.Name;
    }


}
