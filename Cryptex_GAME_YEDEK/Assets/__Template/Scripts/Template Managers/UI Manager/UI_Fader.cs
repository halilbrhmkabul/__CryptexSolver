using Pixelplacement;
using UnityEngine; 
using DG.Tweening; 
using Sirenix.OdinInspector;

public class UI_Fader : Singleton<UI_Fader>
{
    [Title("Fader Options")]
    [SerializeField] Animator animatorFader;
     
    public void FadeAnimation()
    {
        animatorFader.Play("_playFader");
    }
}
