using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private PlayerUpCoin _playerUpCoin;
    [SerializeField] private Text _coinsInWallet;
    [Header("���������� ������")]
    [SerializeField] private int _coin;
    [SerializeField] private int _coinInRound;

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
        _coinInRound++;

        PlayerPrefs.SetInt("SaveCoins", _coin);
        ChangeCoins();

//#if !UNITY_EDITOR && UNITY_WEBGL
//        Progress.Instance.Save();
//#endif

    }
    private void ChangeCoins()
    {
        _coinsInWallet.text = "������: " + _coinInRound.ToString();
    }
}
