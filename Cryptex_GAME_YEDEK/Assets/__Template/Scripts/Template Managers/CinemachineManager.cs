using UnityEngine;
using Cinemachine;
using Pixelplacement; 
using Sirenix.OdinInspector;


public class CinemachineManager : Singleton<CinemachineManager>
{
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    [Title("Camera")]
    public Camera MainCamera;
    [SerializeField] StateMachine cinemachineStateMachine;

    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    [Title("Cinemachine Objects")]
    public CinemachineVirtualCamera CinemachineCam00;
    public CinemachineVirtualCamera CinemachineCam01;
    public CinemachineVirtualCamera CinemachineCam02;


    private void OnEnable()
    {
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnTapToPlay += TapToPlay;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnTapToPlay -= TapToPlay;
    }

    void GameWin(int addedCoin)
    {
        cinemachineStateMachine.ChangeState(2);
    }

    void GameLose(int addedCoin)
    {
        cinemachineStateMachine.ChangeState(2);
    }

    void LoadLevel()
    {
        cinemachineStateMachine.ChangeState(0);
    }

    void TapToPlay()
    {
        cinemachineStateMachine.ChangeState(1);
    }
}
