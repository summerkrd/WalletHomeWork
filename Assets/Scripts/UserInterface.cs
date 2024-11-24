using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface
{
    private TextMeshProUGUI _coinsValueText;
    private TextMeshProUGUI _diamondsValueText;
    private TextMeshProUGUI _energyValueText;

    private Slider _timerSlider;
    private List<Image> _timerHearts;

    private Sprite _heart;
    private Sprite _brokenHeart;

    public UserInterface(TextMeshProUGUI coinsValueText, TextMeshProUGUI diamondsValueText, TextMeshProUGUI energyValueText, Slider timerSlider, List<Image> timerHearts, Sprite heart, Sprite brokenHeart)
    {
        _coinsValueText = coinsValueText;
        _diamondsValueText = diamondsValueText;
        _energyValueText = energyValueText;
        _timerSlider = timerSlider;        
        _heart = heart;
        _brokenHeart = brokenHeart;
        _timerHearts = timerHearts;
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

    public void ShowSliderValue(float currentValue, float startValue) => _timerSlider.value = currentValue / startValue;

    public void ShowHeartValue(float currentValue, float startValue)
    {
        int heartIndex = Mathf.FloorToInt(currentValue);
        heartIndex = Mathf.Clamp(heartIndex, 0, _timerHearts.Count - 1);

        if (_timerHearts[heartIndex] != _brokenHeart)
            _timerHearts[heartIndex].sprite = _brokenHeart;

        Debug.Log(heartIndex);

        if (currentValue == startValue)
        {
            foreach (Image image in _timerHearts)
            {
                image.sprite = _heart;
            }
        }
    }
}
