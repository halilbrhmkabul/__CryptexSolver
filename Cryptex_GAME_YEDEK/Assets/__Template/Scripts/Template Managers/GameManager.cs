using UnityEngine;
using System;
using Pixelplacement;
using DG.Tweening;
using Random = UnityEngine.Random;
using Cinemachine;
using Sirenix.OdinInspector;

public class GameManager : Singleton<GameManager>
{
    #region UI Elements

    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    [Title("Game Objects")]
    public bool GameActive = false;
    public GameObject PlayerObject, PlayerChildObject;
    public StateMachine StateMachineGame;


 
    #endregion

    #region Delegates-Events

    private void OnEnable()
    { 
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnTapToPlay += TapToPlay;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void LoadLevel()
    {
        if (PlayerObject != null)
        {
            PlayerObject.SetActive(true);
            PlayerObject.transform.position = Vector3.zero;
            if (PlayerChildObject != null)
            {
                PlayerChildObject.SetActive(true);
                PlayerChildObject.transform.position = Vector3.zero;
            }
        }  
    }

    void GameWin(int coin)
    {
        GameActive = false;

        StateMachineGame.ChangeState(2);
    }

    void GameLose(int coin)
    {
        GameActive = false;

        StateMachineGame.ChangeState(3);
    }

    void TapToPlay()
    {
        GameActive = true;

        StateMachineGame.ChangeState(1);
    }

    #endregion
}