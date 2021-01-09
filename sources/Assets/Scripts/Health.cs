#pragma warning disable 0649

using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public Action OnHealthChanged = delegate { };
    public Action OnDead = delegate { };
    [SerializeField]
    private float maxHP = 100;
    [SerializeField]
    private float drainRate = 2;
    private float currentHP;
    private void Awake()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        ModifyHP(-drainRate * Time.deltaTime);
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void ModifyHP(float amount)
    {
        currentHP += amount;
        ClampHP();
        OnHealthChanged?.Invoke();
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    private void Die()
    {
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
    public bool IsFull => currentHP == maxHP;
    public bool IsDead => currentHP == 0;

}

