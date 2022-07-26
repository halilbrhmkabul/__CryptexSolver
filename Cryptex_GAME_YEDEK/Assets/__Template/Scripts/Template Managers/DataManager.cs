using UnityEngine;
using Pixelplacement;

public class DataManager : Singleton<DataManager>
{
    //Game Data Variables
    public int Level, Coin ;


    public int CollectibleCount;


    private void OnEnable()
    {
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnCollectible += Collectible; 
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnCollectible -= Collectible; 
    }

    void GameWin(int addedCoin)
    { 
        PlayerPrefs.SetInt("level", Level++);
        PlayerPrefs.SetInt("coin", (Coin + addedCoin));
    }

    void GameLose(int addedCoin)
    {
        PlayerPrefs.SetInt("coin", (Coin + addedCoin));
    }

    void LoadLevel()
    { 
        CollectibleCount = 0; 
    }

    void TapToPlay()
    {
    }

    void Collectible(int addedReward)
    {
        CollectibleCount += addedReward;
    }

 


    public void GetPlayerPrefs()
    {
        Level = PlayerPrefs.GetInt("level") + 1;
        Coin = PlayerPrefs.GetInt("coin");
    }
    public void SetPlayerPrefsCoin(int addedCoin)
    { 
        PlayerPrefs.SetInt("coin", (Coin + addedCoin));
        Coin = PlayerPrefs.GetInt("coin");
    }



}
