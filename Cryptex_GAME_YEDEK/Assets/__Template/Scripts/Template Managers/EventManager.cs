using UnityEngine;
using Pixelplacement; 

public class EventManager : Singleton<EventManager>
{
    #region Delegates
    public delegate void OnTapToPlayDelegate();
    public event OnTapToPlayDelegate OnTapToPlay;

    public delegate void OnLoadLevelDelegate();
    public event OnLoadLevelDelegate OnLoadLevel;

    public delegate void OnGameWinDelegate(int GainedCoin);
    public event OnGameWinDelegate OnGameWin;

    public delegate void OnGameLoseDelegate(int GainedCoin);
    public event OnGameLoseDelegate OnGameLose;

    public delegate void OnGainCoinDelegate(int GainedCoin, Vector3 WorldPos);
    public event OnGainCoinDelegate OnGainCoin;

    public delegate void OnCollectibleDelegate(int addedReward);
    public event OnCollectibleDelegate OnCollectible;

    public delegate void OnObstacleDelegate();
    public event OnObstacleDelegate OnObstacle;

    public delegate void OnIdleModeDelegate();
    public event OnIdleModeDelegate OnIdleMode;

    public delegate void OnStartTheGameDelegate();
    public event OnStartTheGameDelegate OnStartTheGame;
    #endregion

    #region Events
    public void TapToPlay()
    {
        OnTapToPlay?.Invoke();
    }

    public void LoadLevel()
    {
        OnLoadLevel?.Invoke();
    }
    public void GameWin(int GainedCoin)
    {
        if (GainedCoin <= 0)
            GainedCoin = 10;

        OnGameWin?.Invoke(GainedCoin);
    }

    public void GameLose(int GainedCoin)
    {
        if (GainedCoin <= 0)
            GainedCoin = 10;

        OnGameLose?.Invoke(GainedCoin);
    }

    public void GainCoin(int GainedCoin, Vector3 WorldPos)
    {
        OnGainCoin?.Invoke(GainedCoin, WorldPos);
    }

    public void Collectible(int addedReward)
    {
        OnCollectible?.Invoke(addedReward);
    }

    public void Obstacle()
    {
        OnObstacle?.Invoke();
    }

    public void IdleMode()
    {
        OnIdleMode?.Invoke();
    }

    public void StartTheGame()
    {
        OnStartTheGame?.Invoke();
    }

    #endregion

}

