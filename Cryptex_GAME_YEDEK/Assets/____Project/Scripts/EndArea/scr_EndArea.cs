using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EndArea : MonoBehaviour
{
    int triggerCount;
     
    private void OnEnable()
    {
        EventManager.Instance.OnStartTheGame += StartTheGame;    
    }

    private void OnDisable()
    {
        EventManager.Instance.OnStartTheGame -= StartTheGame;
    }

    void StartTheGame()
    {
        StartCoroutine(WaitTheLose());
    }


    IEnumerator WaitTheLose()
    {
        yield return BetterWaitForSeconds.Wait(5.5f);

        if (GameManager.Instance.GameActive)
        {
            EventManager.Instance.GameLose(triggerCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tag_Ball") && GameManager.Instance.GameActive)
        {
            triggerCount++;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            CalculateFinish();
        } 
    }

    void CalculateFinish()
    {  
        if (triggerCount>=scr_LevelManager.Instance.BallSizeTarget*.25f)
        {
            StopAllCoroutines();
            StartCoroutine(WaitTheWin());
        }
    }
  
    IEnumerator WaitTheWin()
    {
        yield return BetterWaitForSeconds.Wait(1f);
        EventManager.Instance.GameWin(scr_LevelManager.Instance.BallSizeTarget);
    }
}
