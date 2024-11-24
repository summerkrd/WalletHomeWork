using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Wallet _wallet;
    private Timer _timer;
    private UserInterface _userInterface;
    private Canvas _canvas;

    private void Start()
    {
        _canvas.gameObject.SetActive(true);
        _wallet.Changed += _userInterface.RefreshUIText;

        _timer = new Timer(this);
        _timer.Changed += _userInterface.ShowSliderValue;
        _timer.Changed += _userInterface.ShowHeartValue;
    }    

    public void Init(Wallet wallet, UserInterface userInterface, Canvas canvas)
    {
        _wallet = wallet;
        _userInterface = userInterface;
        _canvas = canvas;
    }

    private void Update()
    {
        GetMoreCoins();

        GetMoreDiamond();

        GetMorePower();

        StartTimer();

        PauseTimer();

        ResetTimer();
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

    private void StartTimer()
    {
        if (Input.GetKeyDown(KeyCode.S))
            _timer.StartTimer();
    }

    private void PauseTimer()
    {
        if (Input.GetKeyDown(KeyCode.P))
            _timer.PauseTimer();
    }

    private void ResetTimer()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _timer.ResetTimer();
    }
}
