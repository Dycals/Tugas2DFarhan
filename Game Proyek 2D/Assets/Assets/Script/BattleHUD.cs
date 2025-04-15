using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;  // Ganti jadi TextMeshPro
    public Image hpBar;               // Ganti Slider jadi Image Filled

    private int maxHP;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        maxHP = unit.maxHP;
        SetHP(unit.currentHP); // Set awal posisi HP bar
    }

    public void SetHP(int currentHP)
    {
        float fillAmount = (float)currentHP / maxHP;
        hpBar.fillAmount = fillAmount;
    }
}
