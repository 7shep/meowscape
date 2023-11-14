using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;
    [Space]
    public float mana;
    public float maxMana = 100f;

    [Header("UI")]
    public StatsBar healthBar;
    public StatsBar manaBar;


    [Header("Stats Depletion(test)")]
    public float manaDepletion = 0.5f;


    private void Start()
    {
        health = maxHealth;
        mana = maxMana;

    }

    private void Update()
    {
        UpdateStats();
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.numberText.text = health.ToString("f0");
        healthBar.bar.fillAmount = health / 100;

        manaBar.numberText.text = mana.ToString("f0");
        manaBar.bar.fillAmount = mana / 100;
    }

    private void UpdateStats()
    {
        if(health <= 0)
            health = 0;
        if(mana <= 0)
            mana = 0;
        if(health >= maxHealth)
            health= maxHealth;
        if(mana >= maxMana)
            mana = maxMana;


        if (mana > 0)
            mana -= manaDepletion * Time.deltaTime;

    }   
}
