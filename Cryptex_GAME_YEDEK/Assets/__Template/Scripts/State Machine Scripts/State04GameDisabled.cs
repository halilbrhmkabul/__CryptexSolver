using UnityEngine;
using Pixelplacement;
using DG.Tweening;

public class State04GameDisabled : State
{

    private void OnEnable()
    {  
        GameManager.Instance.StateMachineGame.ChangeState(0);
    }

    private void OnDisable()
    {  
        System.GC.Collect();
    }

   
}
