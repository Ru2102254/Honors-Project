using UnityEngine;

public class DataCarryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string NameData;
    public int MaxHPData;
    public int CurrHPData;
    public int LevelData;
    public int Damagedata;
    public int ExpToNextData;
    public int CurrEXPData;

    public string nameData { get => NameData; set => NameData = value; }
    public int maxHPData { get => MaxHPData; set => MaxHPData = value; }
    public int currHPData { get => CurrHPData; set => CurrHPData = value; }
    public int levelData { get => LevelData; set => LevelData = value; }
    public int damageData { get => Damagedata; set => Damagedata = value; }
    public int expToNextData { get => ExpToNextData; set => ExpToNextData = value; }
    public int currEXPData { get => CurrEXPData; set => CurrEXPData = value; }

    public static DataCarryScript instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // If a duplicate exists, destroy the new one
            Destroy(gameObject);
            return;
        }

        // If no instance exists, set this as the instance
        instance = this;

        // Mark the GameObject to not be destroyed when a new scene loads
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
