using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyUnit;

    public TextMeshProUGUI dialogueText;
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Button attackButton;

    private bool playerTurn = true;

    void Start()
    {
        StartBattle();
    }

    void StartBattle()
    {
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        dialogueText.text = "A wild " + enemyUnit.unitName + " appeared!";

        attackButton.interactable = true; // Aktifkan tombol di awal
    }

    public void OnAttackButton()
    {
        if (playerTurn)
        {
            attackButton.interactable = false; // Disable langsung saat diklik
            StartCoroutine(PlayerAttack());
        }
    }

    IEnumerator PlayerAttack()
    {
        enemyUnit.TakeDamage(playerUnit.attackDamage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "You attacked!";

        yield return new WaitForSeconds(1f);

        if (enemyUnit.currentHP <= 0)
        {
            dialogueText.text = "Enemy fainted!";
        }
        else
        {
            playerTurn = false;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Enemy attacks!";
        yield return new WaitForSeconds(1f);

        playerUnit.TakeDamage(enemyUnit.attackDamage);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (playerUnit.currentHP <= 0)
        {
            dialogueText.text = "You fainted!";
        }
        else
        {
            playerTurn = true;
            dialogueText.text = "Choose your action!";
            attackButton.interactable = true; // Aktifkan lagi saat giliran player
        }
    }
}
