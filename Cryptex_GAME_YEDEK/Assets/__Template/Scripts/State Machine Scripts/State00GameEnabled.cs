using UnityEngine;
using Pixelplacement;
using DG.Tweening;

public class State00GameEnabled : State
{

    private void OnEnable()
    {  
        DOTween.Clear();
        EventManager.Instance.LoadLevel(); 
    }  
}
