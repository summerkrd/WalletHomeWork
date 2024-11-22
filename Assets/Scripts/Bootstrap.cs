using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("User Interface")]    
    [SerializeField] private TextMeshProUGUI _coinsValueText;
    [SerializeField] private TextMeshProUGUI _diamondsValueText;
    [SerializeField] private TextMeshProUGUI _energyValueText;

    [Header("Game Manager")]
    [SerializeField] private GameManager _gameManagerPrefab;
    [SerializeField] private int _currencyMaxValue;
    

    private void Awake()
    {
        GameManager gameManager = Instantiate(_gameManagerPrefab);

        Wallet wallet = new Wallet(_currencyMaxValue);
        UserInterface userInterface = new UserInterface(_coinsValueText, _diamondsValueText, _energyValueText);

        gameManager.Init(wallet, userInterface);
    }
}
