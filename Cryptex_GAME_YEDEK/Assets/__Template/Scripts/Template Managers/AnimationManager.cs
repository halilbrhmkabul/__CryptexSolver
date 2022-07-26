using UnityEngine;
using Pixelplacement;

public class AnimationManager : Singleton<AnimationManager>
{
    public Animator AnimatorPlayer;
 
    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        //EventManager.Instance.OnObstacle += Obstacle;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        //EventManager.Instance.OnObstacle -= Obstacle;
    }

    void LoadLevel()
    {
        AnimatorPlayer.Play("_idle");
    }

    void TapToPlay()
    {
        //playerAnimator.Play("_run");
        AnimatorPlayer.Play("_walk");
    }

    void GameWin(int addedReward)
    {
        AnimatorPlayer.Play("_win");
    }
    void GameLose(int addedReward)
    {
        AnimatorPlayer.Play("_lose");
    } 
    //void Obstacle()
    //{ 
    //}

    public void SetAnimator(Animator animator)
    {
        AnimatorPlayer = animator;

        if (GameManager.Instance.GameActive)
        {
            AnimatorPlayer.Play("_run");
        }

        else
        {
            AnimatorPlayer.Play("_idle");
        }
    }

    public void PlayAnimation(string animationName)
    {
        AnimatorPlayer.Play(animationName);
    }

}
