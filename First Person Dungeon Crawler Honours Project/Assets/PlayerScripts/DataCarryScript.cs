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
    public int CurrMoneyData;
    public bool MovementDisabled;
    public Vector3 PlayerPositionData;
    public string LocationData;
    public bool InBattleData;
    public int KeysData;

    public string nameData { get => NameData; set => NameData = value; }
    public int maxHPData { get => MaxHPData; set => MaxHPData = value; }
    public int currHPData { get => CurrHPData; set => CurrHPData = value; }
    public int levelData { get => LevelData; set => LevelData = value; }
    public int damageData { get => Damagedata; set => Damagedata = value; }
    public int expToNextData { get => ExpToNextData; set => ExpToNextData = value; }
    public int currEXPData { get => CurrEXPData; set => CurrEXPData = value; }
    public int currMoneydata { get => CurrMoneyData; set => CurrMoneyData = value; }
    public bool movementDisabled { get => MovementDisabled; set => MovementDisabled = value; }
    public Vector3 playerposition { get => PlayerPositionData; set => PlayerPositionData = value; }
    public string locationData { get => LocationData; set => LocationData = value; }
    public bool inbattleData { get => InBattleData; set => InBattleData = value; }
    public int keysData { get => KeysData; set => KeysData = value; }

    public static DataCarryScript instance;

    private void Awake()
    {
        locationData = "Floor 1";
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
