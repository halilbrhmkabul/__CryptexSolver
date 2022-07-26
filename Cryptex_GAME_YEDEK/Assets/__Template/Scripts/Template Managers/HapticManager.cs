using UnityEngine;
using Pixelplacement; 
using UnityEngine.UI;

public class HapticManager : Singleton<HapticManager>
{


    private void OnEnable()
    {
        Vibration.Init();
        
        EventManager.Instance.OnCollectible += Collectible;
        EventManager.Instance.OnObstacle += Obstacle;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        //EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGainCoin += GainCoin;

    }

    private void OnDisable()
    {
        EventManager.Instance.OnCollectible -= Collectible;
        EventManager.Instance.OnObstacle -= Obstacle;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        //EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnGainCoin -= GainCoin;
    }

    private void Start()
    {
        foreach (Button item in Resources.FindObjectsOfTypeAll<Button>())
        {
            item.onClick.AddListener(() => ButtonHaptic(item));
        }
    }
    void ButtonHaptic(Button item)
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
        Vibration.VibratePop();
    }
    void GameWin(int addedCoin)
    {
        //MMVibrationManager.Haptic(HapticTypes.Success, false, true, this);
        Vibration.VibratePop();

    }

    void GameLose(int addedCoin)
    {
        //MMVibrationManager.Haptic(HapticTypes.Failure, false, true, this);
        Vibration.VibratePop();
    }

    //void LoadLevel()
    //{

    //}

    void TapToPlay()
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this); 
        Vibration.VibratePop();
    }
    void Collectible(int addedReward)
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
        Vibration.VibratePop();
    }

    void Obstacle()
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
        Vibration.VibratePop();
    }
    void GainCoin(int gainedCoin, Vector3 worldPos)
    {
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
        Vibration.VibratePop();
    }
}
