using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private PlayerUpCoin _playerUpCoin;
    [Header("Мониторинг данных")]
    [SerializeField] private int _coin;

    public int Coin => _coin;

    private void Awake()
    {
        _coin = PlayerPrefs.GetInt("SaveCoins");
    }

    private void OnEnable()
    {
        _playerUpCoin.UpCoin += AddCoin;
    }

    private void OnDisable()
    {
        _playerUpCoin.UpCoin -= AddCoin;
    }

    public void ClearWallet()
    {
        _coin = 0;
        PlayerPrefs.SetInt("SaveCoins", _coin);
    }

    private void AddCoin()
    {
        _coin++;
        PlayerPrefs.SetInt("SaveCoins", _coin);
    }
}
