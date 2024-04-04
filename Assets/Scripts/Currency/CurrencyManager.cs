using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private const string CurrencyKey = "PlayerCurrency";
    private int currencyAmount = 0;

    private void Start()
    {
        LoadCurrency();
    }

    public void AddCurrency(int amount)
    {
        currencyAmount += amount;
        SaveCurrency();
    }

    public void SpendCurrency(int amount)
    {
        if (currencyAmount >= amount)
        {
            currencyAmount -= amount;
            SaveCurrency();
            Debug.Log("Currency spent: " + amount);
        }
        else
        {
            Debug.Log("Not enough currency!");
        }
    }

    private void SaveCurrency()
    {
        PlayerPrefs.SetInt(CurrencyKey, currencyAmount);
        PlayerPrefs.Save();
    }

    private void LoadCurrency()
    {
        if (PlayerPrefs.HasKey(CurrencyKey))
        {
            currencyAmount = PlayerPrefs.GetInt(CurrencyKey);
        }
        else
        {
            currencyAmount = 0; // Default value if no currency found
        }
    }

    public void ResetCurrency()
    {
        currencyAmount = 0;
        SaveCurrency();
        Debug.Log("Currency reset to zero.");
    }

    public int GetCurrencyAmount()
    {
        return currencyAmount;
    }
}
