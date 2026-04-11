using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERPHASE, ENEMYPHASE, WIN, LOSE, WAIT }

public class BattleStstem : MonoBehaviour
{

    public BattleState currState;
    public GameObject BatEnemy;
    public GameObject TreeEnemy;
    public GameObject SeaDragon;


    public GameObject Enemy_Boss;

    public Transform enemyBattleStation;
    public Transform playerBattleStation;

    EnemyScript enemyUnit;

    public TextMeshProUGUI dialogueText;

    public HUDScript playerHUD;
    public HUDScript enemyHUD;


    public GameObject enemyEncountered;

    public bool BossEncounter;

    public GameObject customisationOptions;

    void Awake()
    {
        BossEncounter = DataCarryScript.instance.BossEnemy;
        DataCarryScript.instance.movementDisabled = true;
        currState = BattleState.START;
        FindFirstObjectByType<AudioManager>().Stop("Explore");
        StartCoroutine(BattleSetup());
    }

    IEnumerator BattleSetup()
    {
        if (!BossEncounter) {
            FindFirstObjectByType<AudioManager>().Play("Battle");
            int randLowLimit = 1;
            int randHighLimit = 100;
            int randEnenmy = 60;
            int randEnenmy2 = 80;
            if (Random.Range(randLowLimit, randHighLimit) <= randEnenmy)
            {
                enemyEncountered = BatEnemy;
            }
            else if (Random.Range(randLowLimit,randHighLimit) <= randEnenmy2) {
            
                enemyEncountered = TreeEnemy; 
            }
            else {
                
                    enemyEncountered = SeaDragon;
            }
        }
        else
        {
            FindFirstObjectByType<AudioManager>().Play("FinalBoss");
            enemyEncountered = Enemy_Boss;
        }


        GameObject enemyGO = Instantiate(enemyEncountered, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<EnemyScript>();
        dialogueText.text = "Accosted by " + enemyUnit.eName;

        playerHUD.setHUD();

        customisationOptions = GameObject.Find("BattleCustomCanvas");
        customisationOptions.GetComponent<CustomisingUI>().SetUI();


        yield return new WaitForSeconds(3f);
        currState = BattleState.PLAYERPHASE;
        PlayerPhase();
    }

    IEnumerator PlayerAttack()
    {

        //Inflict Damage

        currState = BattleState.WAIT;

        bool isdead = enemyUnit.TakeDamage(DataCarryScript.instance.damageData);
        dialogueText.text = DataCarryScript.instance.nameData + " hit for " + DataCarryScript.instance.damageData;
        yield return new WaitForSeconds(2f);

        

        dialogueText.text = "attack hit";

        if (isdead)
        {
            currState = BattleState.WIN;
            StartCoroutine(ValueGain());
        }
        else
        {
            currState = BattleState.ENEMYPHASE;
            StartCoroutine(EnemyPhase());
        }
    }

    public IEnumerator TalkStopFight()
    {
        currState = BattleState.WAIT;
        int RandStopFight = 20;
        int RandStopFightLow = 1;
        int RandStopFightLimit= 100;

        if (!BossEncounter)
        {
            dialogueText.text = "You want to stop?";
            yield return new WaitForSeconds(1f);
            if (Random.Range(RandStopFightLow, RandStopFightLimit) <= RandStopFight)
            {
                EndBattle();
            }
            else
            {
                dialogueText.text = "" + enemyEncountered.name + " refuses to stop";
                yield return new WaitForSeconds(1f);
                currState = BattleState.ENEMYPHASE;
                StartCoroutine(EnemyPhase());
            }
        }
        else
        {
            dialogueText.text = "Can't abscond " + playerHUD.playerName;
        }
    }

    IEnumerator TalkItem()
    {
        currState = BattleState.WAIT;
        int RandItem = 20;
        int RandItemLow = 1;
        int RandItemLimit = 100;
        if (!BossEncounter)
        {
            dialogueText.text = "You want an item?";
            yield return new WaitForSeconds(1f);
            if (Random.Range(RandItemLow, RandItemLimit) <= RandItem)
            {
                dialogueText.text = "You got a ";
                yield return new WaitForSeconds(1f);
                currState = BattleState.WIN;
                EndBattle();
            }
            else
            {
                dialogueText.text = "" + enemyEncountered.name + " doesn't give anything";
                yield return new WaitForSeconds(1f);
                currState = BattleState.ENEMYPHASE;
                StartCoroutine(EnemyPhase());
            }
        }
        else
        {
            dialogueText.text = "Can't abscond " + playerHUD.playerName;
        }
    }
    IEnumerator TalkMoney()
    {
        currState = BattleState.WAIT;
        int RandItem = 20;
        int RandItemLow = 1;
        int RandItemLimit = 100;
        int MoneyGain = enemyUnit.MoneyDrop;

        if (!BossEncounter)
        {
            dialogueText.text = "You want an item?";
            yield return new WaitForSeconds(0.1f);
            if (Random.Range(RandItemLow, RandItemLimit) <= RandItem)
            {
                DataCarryScript.instance.CurrMoneyData += MoneyGain;
                dialogueText.text = "You got " + MoneyGain + " money!";
                yield return new WaitForSeconds(1);
                currState = BattleState.WIN;
                EndBattle();
            }
            else
            {
                currState = BattleState.ENEMYPHASE;
                StartCoroutine(EnemyPhase());
            }
        }
        else
        {
            dialogueText.text = "Can't abscond " + playerHUD.playerName;
        }
    }

    IEnumerator Abscond()
    {
        currState = BattleState.WAIT;
        int RandItem = 20;
        int RandItemLow = 1;
        int RandItemLimit = 100;
        if (!BossEncounter)
        {
            dialogueText.text = "You want to run?";
            yield return new WaitForSeconds(1f);
            if (Random.Range(RandItemLow, RandItemLimit) <= RandItem)
            {
                dialogueText.text = "You got away safely!";
                yield return new WaitForSeconds(1f);
                currState = BattleState.WIN;
                EndBattle();
            }
            else
            {
                currState = BattleState.ENEMYPHASE;
                StartCoroutine(EnemyPhase());
            }
        }
        else
        {
            dialogueText.text = "Can't abscond " + playerHUD.playerName;
            PlayerPhase();
        }
            
    }

    void PlayerPhase()
    {
        dialogueText.text = "What do you do";
    }

    public void OnAttack()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnTalk(int talkValue)
    {
        if (currState != BattleState.PLAYERPHASE) return;
        dialogueText.text = "What do you want";
        switch (talkValue)
        {
            case 0:
                StartCoroutine(TalkStopFight());
                break;
            case 1:
                StartCoroutine(TalkItem());
                break;
            case 2:
                StartCoroutine(TalkMoney());
                break;
        }
    }


    public void UseHealingItem()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        currState = BattleState.WAIT;

        if (DataCarryScript.instance.currHPData < DataCarryScript.instance.maxHPData)
        {
            DataCarryScript.instance.currHPData += 10;
            if (DataCarryScript.instance.currHPData > DataCarryScript.instance.maxHPData)
            {
                DataCarryScript.instance.currHPData = DataCarryScript.instance.maxHPData;
            }
            playerHUD.setHP(DataCarryScript.instance.currHPData);
        }
        currState = BattleState.ENEMYPHASE;
        StartCoroutine(EnemyPhase());
    }

    public void OnAbscond()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        StartCoroutine(Abscond());
    }

    IEnumerator EnemyPhase()
    {
        dialogueText.text = enemyUnit.eName + " is Attacking";
        yield return new WaitForSeconds(1f);

        bool isdead = TakeDamage(enemyUnit.eDamage);
        playerHUD.setHP(DataCarryScript.instance.currHPData);

        yield return new WaitForSeconds(1f);

        if (isdead)
        {
            currState = BattleState.LOSE;
            EndBattle();
        }
        else {
            currState = BattleState.PLAYERPHASE;
            PlayerPhase();
        }
    }

    bool TakeDamage(int dmg)
    {
        int defRedDamage = DataCarryScript.instance.defenseData / 10;
        int trueDmg = dmg - defRedDamage;
        DataCarryScript.instance.currHPData -= trueDmg;
        if (DataCarryScript.instance.currHPData <= 0)
            return true;
        else
            return false;
    }

    IEnumerator ValueGain()
    {
        dialogueText.text = "You Win";
        yield return new WaitForSeconds(1f);
        int MoneyGain = enemyUnit.MoneyDrop;
        int EXPGain = enemyUnit.expDrop;
        dialogueText.text = "You got " + MoneyGain + " Money and " + EXPGain + " EXP";
        yield return new WaitForSeconds(1f);
        DataCarryScript.instance.currMoneydata += MoneyGain;
        playerHUD.gainEXP(EXPGain);
        EndBattle();
    }


    void EndBattle()
    {
        switch (currState)
        {
            case BattleState.WIN:
                if (!BossEncounter)
                {
                    FindFirstObjectByType<AudioManager>().Stop("Battle");
                    FindFirstObjectByType<AudioManager>().Play("Explore");
                    Destroy(enemyUnit.gameObject);
                    SceneManager.UnloadSceneAsync("Battle");
                    DataCarryScript.instance.movementDisabled = false;
                    DataCarryScript.instance.inbattleData = false;
                    return;
                }
                FindFirstObjectByType<AudioManager>().Stop("FinalBoss");
                FindFirstObjectByType<AudioManager>().Play("Win");
                SceneManager.LoadScene("Winning");
                return;
            case BattleState.LOSE:
                FindFirstObjectByType<AudioManager>().Stop("FinalBoss");
                FindFirstObjectByType<AudioManager>().Stop("Battle");
                FindFirstObjectByType<AudioManager>().Play("Death");
                SceneManager.LoadScene("Game Over");
                return;
        }
        
    }
}
