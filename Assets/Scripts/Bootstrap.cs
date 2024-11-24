using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [Header("User Interface")]    
    [SerializeField] private Canvas _canvas;
    [Space]
    [SerializeField] private TextMeshProUGUI _coinsValueText;
    [SerializeField] private TextMeshProUGUI _diamondsValueText;
    [SerializeField] private TextMeshProUGUI _energyValueText;
    [Space]
    [SerializeField] private Slider _slider; 
    [Space]
    [SerializeField] private Sprite _heartSprite;
    [SerializeField] private Sprite _brokenHeartSprite;
    [SerializeField] private List<Image> _hearts;

    [Header("Game Manager")]
    [SerializeField] private GameManager _gameManagerPrefab;
    [SerializeField] private int _currencyMaxValue;
    

    private void Awake()
    {
        GameManager gameManager = Instantiate(_gameManagerPrefab);

        Wallet wallet = new Wallet(_currencyMaxValue);
        UserInterface userInterface = new UserInterface(_coinsValueText, _diamondsValueText, _energyValueText, _slider, _hearts, _heartSprite, _brokenHeartSprite);

        gameManager.Init(wallet, userInterface, _canvas);
    }
}
