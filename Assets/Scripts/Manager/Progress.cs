//using System.Runtime.InteropServices;
//using UnityEngine;

//[System.Serializable]
//public class PlayerInfo
//{
//    public int HighScore;
//    public int Coin;
//}

//public class Progress : MonoBehaviour
    
//{
//    [SerializeField] private ScoreManager _scoreManager;
//    [SerializeField] private Wallet _wallet;

//    public PlayerInfo PlayerInfo;

//    [DllImport("__Internal")]
//    private static extern void SaveExtern(string date);
//    [DllImport("__Internal")]
//    private static extern void LoadExtern();

//    public static Progress Instance;
//    private void Awake()
//    {
//        if(Instance == null)
//        {
//            Instance = this;
//        }

//        _scoreManager = GetComponent<ScoreManager>();
//        _wallet = GetComponent<Wallet>();
        
//    }

//    private void Start()
//    {
//           LoadExtern();
//    }

//    public void Save()
//    {
//        PlayerInfo.HighScore = _scoreManager.HighScore;
//        PlayerInfo.Coin = _wallet.Coin;
//        string jsonString = JsonUtility.ToJson(PlayerInfo);
//        SaveExtern(jsonString);
//    }

//    public void SetPlayerInfo(string value)
//    {
//        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
//    }
//}
