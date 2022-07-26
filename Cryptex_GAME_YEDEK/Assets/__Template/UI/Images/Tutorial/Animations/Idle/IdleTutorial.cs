using System.Collections;
using UnityEngine;

public class IdleTutorial : MonoBehaviour
{ 
    [SerializeField] float tutorialAnimationPlayTime; 

    void Start()
    {
        if (DataManager.Instance.Level == 0)
        {
            EventManager.Instance.OnIdleMode += IdleMode;
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (DataManager.Instance.Level == 0)
        {
            EventManager.Instance.OnTapToPlay -= IdleMode;
        }
    }

    void IdleMode()
    { 
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        StartCoroutine(waitForTutorial(tutorialAnimationPlayTime));
    }

    IEnumerator waitForTutorial(float tutorialAnimationPlayTimee)
    {
        yield return BetterWaitForSeconds.WaitRealtime(tutorialAnimationPlayTimee);
        gameObject.SetActive(false);
    }
}
