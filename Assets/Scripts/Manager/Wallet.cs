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

    private void Awake()
    {
        if (YG2.isSDKEnabled)
        {
            LoadCoin();
        }
    }

    private void OnEnable()
    {
        _playerUpCoin.UpCoin += AddCoin;
        YG2.onGetSDKData += LoadCoin;
        //YandexGame.GetDataEvent += LoadCoin;
    }

    private void OnDisable()
    {
        _playerUpCoin.UpCoin -= AddCoin;
        YG2.onGetSDKData -= LoadCoin;
        //YandexGame.GetDataEvent += LoadCoin;
    }

    private void AddCoin()
    {
        _coin++;
        _coinInRound++;

        YG2.saves.coins = _coin;
        YG2.SaveProgress();
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
        _coin = YG2.saves.coins;
    }
}
