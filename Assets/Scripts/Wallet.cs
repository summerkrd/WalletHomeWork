using UnityEngine;

public class Wallet
{
    private int _coinValue;
    private int _diamondValue;
    private int _energyValue;

    private int _maxValue;

    public Wallet(int coinValue, int diamondValue, int energyValue, int maxValue)
    {
        _coinValue = coinValue;
        _diamondValue = diamondValue;
        _energyValue = energyValue;
        _maxValue = maxValue;
    }


}
