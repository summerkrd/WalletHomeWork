using System;
using UnityEngine;

public enum Currency
{
    Coin,
    Diamond,
    Energy
}

public class Wallet
{
    public event Action<int, Currency> Changed;

    public Wallet(int maxValue)
    {
        if (maxValue < 0)
            maxValue = 0;

        MaxValue = maxValue;
    }

    public int CoinValue { get; private set; }
    public int DiamondValue { get; private set; }
    public int EnergyValue { get; private set; }
    public int MaxValue { get; }
    
    public bool IsEnoughSpace(int value, Currency currency)
    {
        int currentValue = currency switch
        {
            Currency.Coin => CoinValue,
            Currency.Diamond => DiamondValue,
            Currency.Energy => EnergyValue,
            _ => throw new ArgumentOutOfRangeException(nameof(currency), "Invalid currency type")
        };

        return value + currentValue <= MaxValue;
    }

    public void Add(int value, Currency currency)
    {
        if (value < 0)
            value = 0;

        if (IsEnoughSpace(value, currency) == false)
            throw new ArgumentOutOfRangeException(nameof(value));
                
        switch (currency)
        {
            case Currency.Coin:
                CoinValue += value;
                Debug.Log("CoinValue: " + CoinValue);
                break;

            case Currency.Diamond:
                DiamondValue += value;
                Debug.Log("DiamondValue: " + DiamondValue);
                break;

            case Currency.Energy:
                EnergyValue += value;
                Debug.Log("EnergyValue: " + EnergyValue);
                break;
        }

        Changed?.Invoke(value, currency);        
    }
}
