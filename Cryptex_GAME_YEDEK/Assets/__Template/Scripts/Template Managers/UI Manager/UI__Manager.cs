using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;  


public class UI__Manager : Singleton<UI__Manager>
{
    public CanvasScaler MainCanvasScaler;

    //public MMFeedbacks mmFeedbackScript;
    public float WaitFinalUI;
    public float TextAnimationTimer=0.005f;


    //private void OnEnable()
    //{
    //    EventManager.Instance.OnTapToPlay += TapToPlay;
    //    EventManager.Instance.OnLoadLevel += LoadLevel;
    //    EventManager.Instance.OnGameLose += GameLose;
    //    EventManager.Instance.OnGameWin += GameWin;
    //    EventManager.Instance.OnGainCoin += GainCoin;
    //}
    //private void OnDisable()
    //{
    //    EventManager.Instance.OnTapToPlay -= TapToPlay;
    //    EventManager.Instance.OnLoadLevel -= LoadLevel;
    //    EventManager.Instance.OnGameLose -= GameLose;
    //    EventManager.Instance.OnGameWin -= GameWin;
    //    EventManager.Instance.OnGainCoin -= GainCoin;
    //}

    //void TapToPlay()
    //{

    //}

    //void LoadLevel()
    //{

    //}

    //void GameLose(int gainedCoin)
    //{

    //}

    //void GameWin(int gainedCoin)
    //{

    //}

    //void GainCoin(int gainedCoin, Vector3 worldPos)
    //{

    //}

#if UNITY_EDITOR 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventManager.Instance.GameWin(50);
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            EventManager.Instance.GameLose(0);
        }
    }
#endif
}
