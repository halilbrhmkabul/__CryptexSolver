using UnityEngine;
using Sirenix.OdinInspector;
using Pixelplacement;
using Lean.Common;

public class ControllerManager : Singleton<ControllerManager>
{
    [Title("Runner")]
    public LeanManualTranslate ControllerLeanManualTranslate;

    [Title("Idle")]
    //public FloatingJoystick ControllerFloatingJoystick;


    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
    }

    void TapToPlay()
    {
        if (ControllerLeanManualTranslate != null) //Varsayýlan olarak runnerda kullandýðýmýz için.
        {
            ControllerLeanManualTranslate.enabled = true;
        }
    }

    void GameWin(int addedReward)
    {
        NullCheckAndClose();
    }

    void GameLose(int addedReward)
    {
        NullCheckAndClose();
    }


    void NullCheckAndClose()
    {
        if (ControllerLeanManualTranslate != null)
        {
            ControllerLeanManualTranslate.enabled = false;
        }

        //if (ControllerFloatingJoystick != null)
        //{
        //    ControllerFloatingJoystick.enabled = false;
        //}
    }
}
