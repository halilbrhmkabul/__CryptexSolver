using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Bu scripti character modelinin üstüne býrak.

    [SerializeField] Animator playerAnimator;  
    private void OnEnable()
    {
        AnimationManager.Instance.SetAnimator(playerAnimator); 
    }

}
