using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Wallet _wallet;
    private UserInterface _userInterface;

    private void Start()
    {
        _wallet.Changed += _userInterface.RefreshUIText;
    }

    public void Init(Wallet wallet, UserInterface userInterface)
    {
        _wallet = wallet;
        _userInterface = userInterface;
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
        {
            _wallet.Add(25, Currency.Coin);            
        }
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
