using UnityEngine;
using Pixelplacement;

public class PlayerController : Singleton<PlayerController>
{








    private void OnEnable()
    {
        EventManager.Instance.OnCollectible += Collectible;
        EventManager.Instance.OnObstacle += Obstacle;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnTapToPlay += TapToPlay;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnCollectible -= Collectible;
        EventManager.Instance.OnObstacle -= Obstacle;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
    }


    private void Start()
    {
    }

    void Collectible(int addedReward)
    {
    
    }

    void Obstacle()
    {
    }

    void GameWin(int addedCoin)
    {
    }

    void GameLose(int addedCoin)
    {
    }

    void LoadLevel()
    {
    }

    void TapToPlay()
    { 
    }
}
