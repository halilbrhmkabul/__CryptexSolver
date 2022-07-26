using System.Collections;
using UnityEngine;

public class SwerveTutorial : MonoBehaviour
{ 
    [SerializeField] float tutorialAnimationPlayTime;  

    void Start()
    {
        if (DataManager.Instance.Level==1)
        {
            EventManager.Instance.OnTapToPlay += TapToPlay;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    { 
            EventManager.Instance.OnTapToPlay -= TapToPlay;
        
    }

    void TapToPlay()
    {
        StartCoroutine(waitForTutorial(tutorialAnimationPlayTime));
    }

    IEnumerator waitForTutorial(float tutorialAnimationPlayTimee)
    {
        yield return BetterWaitForSeconds.WaitRealtime(tutorialAnimationPlayTimee);
        gameObject.SetActive(false);
    }
}
