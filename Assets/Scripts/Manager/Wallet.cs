using UnityEngine;
using UnityEngine.UI;
using YG;

public class Wallet : MonoBehaviour
{
    [SerializeField] private PlayerUpCoin _playerUpCoin;
    [SerializeField] private Text _coinsInWallet;
    [Header("Мониторинг данных")]
    [SerializeField] private int _coin;
    [SerializeField] private int _coinInRound;

    public int Coin => _coin;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadCoin();
        }
    }

    private void OnEnable()
    {
        _playerUpCoin.UpCoin += AddCoin;
        YandexGame.GetDataEvent += LoadCoin;
    }

    private void OnDisable()
    {
        _playerUpCoin.UpCoin -= AddCoin;
        YandexGame.GetDataEvent += LoadCoin;
    }

    private void AddCoin()
    {
        _coin++;
        _coinInRound++;

        YandexGame.savesData.Coins = _coin;
        YandexGame.SaveProgress();
        ChangeCoins();

        //#if !UNITY_EDITOR && UNITY_WEBGL
        //        Progress.Instance.Save();
        //#endif

    }
    private void ChangeCoins()
    {
        _coinsInWallet.text = "Монеты: " + _coinInRound.ToString();
    }

    private void LoadCoin()
    {
        _coin = YandexGame.savesData.Coins;
    }
}
