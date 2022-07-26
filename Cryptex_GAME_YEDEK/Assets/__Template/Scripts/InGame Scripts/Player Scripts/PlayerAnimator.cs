using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Bu scripti character modelinin �st�ne b�rak.

    [SerializeField] Animator playerAnimator;  
    private void OnEnable()
    {
        AnimationManager.Instance.SetAnimator(playerAnimator); 
    }

}
