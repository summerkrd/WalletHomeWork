using System;
using System.Collections.Generic;
using UnityEngine;

public enum Currency
{
    Coin,
    Diamond,
    Energy
}

public class Wallet
{
    private Dictionary<Currency, int> _currencies;
    public event Action<int, Currency> Changed;

    public Wallet(int maxValue)
    {
        if (maxValue < 0)
            maxValue = 0;

        MaxValue = maxValue;

        _currencies = new Dictionary<Currency, int>();
        _currencies.Add(Currency.Coin, default);
        _currencies.Add(Currency.Diamond, default);
        _currencies.Add(Currency.Energy, default);
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

        _currencies[currency] += value;

        Changed?.Invoke(_currencies[currency], currency);        
    }
}
