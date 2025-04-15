using UnityEngine;

[System.Serializable]
public class Unit : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int attackDamage;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
}
