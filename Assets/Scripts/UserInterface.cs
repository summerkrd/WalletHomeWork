using System;
using TMPro;
using UnityEngine;

public class UserInterface
{
    private TextMeshProUGUI _coinsValueText;
    private TextMeshProUGUI _diamondsValueText;
    private TextMeshProUGUI _energyValueText;

    public UserInterface(TextMeshProUGUI coinsValueText, TextMeshProUGUI diamondsValueText, TextMeshProUGUI energyValueText)
    {
        _coinsValueText = coinsValueText;
        _diamondsValueText = diamondsValueText;
        _energyValueText = energyValueText;
    }

    public void RefreshUIText(int value, Currency currency)
    {
        var targetText = currency switch
        {
            Currency.Coin => _coinsValueText,
            Currency.Diamond => _diamondsValueText,
            Currency.Energy => _energyValueText,
            _ => throw new ArgumentOutOfRangeException(nameof(currency), "Invalid currency type")
        };

        targetText.text = value.ToString();
    } 
}
