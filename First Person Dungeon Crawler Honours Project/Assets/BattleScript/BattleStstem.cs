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
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform enemyBattleStation;
    public Transform playerBattleStation;

    PlayerStats playerUnit;
    EnemyScript enemyUnit;

    public TextMeshProUGUI dialogueText;

    public HUDScript playerHUD;
    public HUDScript enemyHUD;


    void Start()
    {
        currState = BattleState.START;
        StartCoroutine(BattleSetup());
    }

    IEnumerator BattleSetup()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<PlayerStats>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<EnemyScript>();
        dialogueText.text = "Accosted by " + enemyUnit.eName;

        playerHUD.setHUD(playerUnit);

        yield return new WaitForSeconds(2f);
        currState = BattleState.PLAYERPHASE;
        PlayerPhase();
    }

    IEnumerator PlayerAttack()
    {
        //Inflict Damage
        bool isdead = enemyUnit.TakeDamage(playerUnit.Damage);
        yield return new WaitForSeconds(2f);

        currState = BattleState.WAIT;

        dialogueText.text = "attack hit";

        if (isdead)
        {
            currState = BattleState.WIN;
            EndBattle();
        }
        else
        {
            currState = BattleState.ENEMYPHASE;
            StartCoroutine(EnemyPhase());
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

    public void OnTalk()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnItem()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnAbscond()
    {
        if (currState != BattleState.PLAYERPHASE) return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator EnemyPhase()
    {
        dialogueText.text = enemyUnit.eName + " is Attacking";
        yield return new WaitForSeconds(1f);

        bool isdead = playerUnit.TakeDamage(enemyUnit.eDamage);
        playerHUD.setHP(playerUnit.CurrentHP);

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

    void EndBattle()
    {
        switch (currState)
        {
            case BattleState.WIN:

                return;
            case BattleState.LOSE:
                SceneManager.LoadScene("Game Over");
                return;
        }
        
    }

}
