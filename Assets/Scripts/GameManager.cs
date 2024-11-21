using UnityEngine;

public class GameManager : MonoBehaviour
{
    Wallet _wallet;

    private void Start()
    {
        _wallet = new Wallet(100);
    }

    private void Update()
    {
        GetMoreCoins();

        GetMoreDiamond();

        GetMorePower();
    }

    private void GetMoreCoins()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _wallet.Add(25, Currency.Coin);
    }

    private void GetMoreDiamond()
    {
        if (Input.GetKeyDown(KeyCode.D))
            _wallet.Add(5, Currency.Diamond);
    }

    private void GetMorePower()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _wallet.Add(15, Currency.Energy);
    }
}
