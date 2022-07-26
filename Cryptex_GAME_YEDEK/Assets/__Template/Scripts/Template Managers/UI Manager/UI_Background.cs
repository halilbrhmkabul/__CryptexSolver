using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;
using DG.Tweening;  
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;


public class UI_Background : MonoBehaviour
{
    [Title("Panel Background")]
    [SerializeField] GameObject panelBackground; 
    //[SerializeField] Image imageUp; float imageUpStartY;
    [SerializeField] Image imageBackground;


    private void OnEnable()
    {
        //EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnGameWin += GameWin;
        //EventManager.Instance.OnGainCoin += GainCoin;
    }
    private void OnDisable()
    {
        //EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnGameWin -= GameWin;
        //EventManager.Instance.OnGainCoin -= GainCoin;
    }

    private void Start()
    {
        //imageUpStartY = imageUp.transform.localPosition.y;
    }


    //void TapToPlay()
    //{

    //}

    void LoadLevel()
    {
        panelBackground.SetActive(false); 
    }

    void GameLose(int gainedCoin)
    {
        StartCoroutine(CallTheBackground( ));
    }

    void GameWin(int gainedCoin)
    {
        StartCoroutine(CallTheBackground( ));
    }

    //void GainCoin(int gainedCoin, Vector3 worldPos)
    //{

    //}

    IEnumerator CallTheBackground( )
    { 
        //imageUp.transform.localPosition = new Vector3(0, (imageUpStartY)  , 0); 
        
        imageBackground.transform.localScale = new Vector3(2,2,2);
        imageBackground.gameObject.SetActive(false);
        imageBackground.DOFade(0, .01f);

        panelBackground.SetActive(true);

        //imageUp.transform.DOLocalMoveY(imageUpStartY - imageUp.preferredHeight, UI__Manager.Instance.WaitFinalUI + .5f);
        yield return BetterWaitForSeconds.Wait(UI__Manager.Instance.WaitFinalUI);

        imageBackground.DOFade(.7f, UI__Manager.Instance.WaitFinalUI * .5f);
        imageBackground.gameObject.SetActive(true);
        //imageBackground.transform.DOScale(new Vector3(1,1,1),2.5f).SetEase(Ease.InOutQuart);
    }
}
