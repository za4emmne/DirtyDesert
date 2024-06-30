using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject _menu;
    [SerializeField] private UnityEngine.GameObject _shop;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _coinsInWallet;
    [SerializeField] private Text _shopText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Wallet _wallet;

    private string _coinName;

    private void Start()
    {
        ChangeHighSCore();
        ChangeCoins();
        _shop.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShopActive()
    {
        //StartCoroutine(Shop());
        _menu.SetActive(false);
        _shop.SetActive(true);
        _shopText.color = Color.Lerp(Color.clear, Color.black, 1f);

        _shop.GetComponent<Animator>().SetTrigger("Idle");
    }

    

    public void ShopExit()
    {
        _shop.SetActive(false);
        _menu.SetActive(true);
    }

    public void ChangeHighSCore()
    {
        _highScoreText.text = "Рекорд: " + _scoreManager.HighScore.ToString();
    }

    public void ChangeCoins()
    {
        _coinsInWallet.text = _wallet.Coin.ToString() + "";
    }

    //private IEnumerator Shop()
    //{
    //    while (true)
    //    {
    //        _menu.SetActive(false);
    //        _shop.SetActive(true);

    //        var waitForSeconds = new WaitForSeconds(0.1f);
    //        yield return waitForSeconds;

    //        _shop.GetComponent<Animator>().SetTrigger("Idle");
    //    }
    //}
}
