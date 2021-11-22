﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] string playerName;

    [SerializeField] Sprite charcterImage;

    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int maxLevel = 50;
    [SerializeField] int[] xpForNextLevel;
    [SerializeField] int baseLevelXP = 100;
    private float hpGrow = 1.18f;
    private float manaGrow = 1.06f;

    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP;

    [SerializeField] int maxMana=30;
    [SerializeField] int currnetMana;

    [SerializeField] int defence;
    [SerializeField] int dexterity;

    private float[] expCalc = { 0.02f, 3.06f, 105.6f };



    // Start is called before the first frame update
    void Start()
    {
        xpForNextLevel = new int[maxLevel];
        xpForNextLevel[1] = baseLevelXP;
        for(int i = 2; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = (int)(expCalc[0]*i*i*i+expCalc[1]*i*i+expCalc[2]*i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(baseLevelXP);
        }
    }

    public void AddXP(int amountOfXp)
    {
        currentXP += amountOfXp;
        if (currentXP > xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;
            maxHP = (int)(maxHP * hpGrow);
            currentHP = maxHP;
            maxMana = (int)(maxMana * manaGrow);
            currnetMana = maxMana;
            if (playerLevel % 2 == 0)
            {
                dexterity++;
            }
            else
            {
                defence++;
            }
        }
    }
    public string GetPlayerName()
    {
        return playerName;
    }
    public Sprite GetCharcterImage()
    {
        return charcterImage;
    }
    public int GetPlayerLevel()
    {
        return playerLevel;
    }
    public int GetCurrentXP()
    {
        return currentXP;
    }
    public int GetMaxLevel()
    {
        return maxLevel;
    }
    public int[] GetXpForNextLevel()
    {
        return xpForNextLevel;
    }
    public int GetBaseLevelXP()
    {
        return baseLevelXP;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    public int GetMaxMana()
    {
        return maxMana;
    }
    public int GetCurrnetMana()
    {
        return currnetMana;
    }
    public int GetDefence()
    {
        return defence;
    }
    public int GetDexterity()
    {
        return dexterity;
    }
}
