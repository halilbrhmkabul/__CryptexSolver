using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using DG.Tweening;   
using Sirenix.OdinInspector;


public class UI_Reward : MonoBehaviour
{
    [Title("Panel Reward")]
    [SerializeField] GameObject panelReward;

    [Title("Collect")]
    [SerializeField] Button btnCollect;
    [SerializeField] TextMeshProUGUI textCollect;
    [SerializeField] TextMeshProUGUI textCalculatedMargin;
    int coin;


    [Title("Margin")]
    [SerializeField] Image imgMarginSlider;
    [SerializeField] GameObject objMarginArrow;
    float _eulerX;
    bool _calculator;


    [Title("Coin Image")]
    [SerializeField] GameObject imgCoinRandom;
    [SerializeField] GameObject imgCoinBase;
    [SerializeField] List<Image> ListImgCoinRandom;

 
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


    private void Update()
    {
        if (_calculator)
        {
            _eulerX = objMarginArrow.transform.localEulerAngles.z;
            textCalculatedMargin.text = (MarginCalculate(_eulerX) * coin).ToString();
        }
    }


    //void TapToPlay()
    //{

    //}

    void LoadLevel()
    {
        panelReward.SetActive(false);
    }

    void GameLose(int gainedCoin)
    {
        StartCoroutine(RewardCaseOpen(gainedCoin));
    }

    void GameWin(int gainedCoin)
    {
        StartCoroutine(RewardCaseOpen(gainedCoin));
    }

    //void GainCoin(int gainedCoin, Vector3 worldPos)
    //{

    //}


    public void CollectMargin()
    {
        textCollect.text = "Profit!";
        btnCollect.enabled = false;



        _calculator = false;
        MarginCalculate(objMarginArrow.transform.localEulerAngles.z);
        DOTween.Kill(objMarginArrow.transform);

        DataManager.Instance.GetPlayerPrefs();
        UI_Game.Instance.CoinTextAnimation(DataManager.Instance.Coin, DataManager.Instance.Coin + MarginCalculate(_eulerX) * coin);

        StartCoroutine(CoinImageAnimation());

        DataManager.Instance.SetPlayerPrefsCoin(MarginCalculate(_eulerX) * coin);
        StartCoroutine(GoNextLevel());


    }


    IEnumerator RewardCaseOpen(int gainedCoin)
    {

        textCollect.text = "Collect!";
        btnCollect.enabled = true;
        coin = gainedCoin;
        _calculator = true;
        MarginArrowAnimation();

        panelReward.transform.localScale = Vector3.zero;
        btnCollect.transform.localScale = Vector3.one;


        yield return BetterWaitForSeconds.Wait(UI__Manager.Instance.WaitFinalUI);

        panelReward.SetActive(true);
        panelReward.transform.DOScale(Vector3.one, .5f)
            .OnComplete(() =>
            {
                StartCoroutine(CoinImageAnimation());
            });

    }


    IEnumerator GoNextLevel()
    {
        yield return BetterWaitForSeconds.Wait(2f);
        //UI__Manager.Instance.mmFeedbackScript?.PlayFeedbacks();
        UI_Fader.Instance.FadeAnimation();
        yield return BetterWaitForSeconds.Wait(1f);
        GameManager.Instance.StateMachineGame.ChangeState(4);
    }



    IEnumerator CoinImageAnimation()
    {
        //-------------------- Coin Animation
        imgCoinRandom.SetActive(true);
        for (int i = 0; i < ListImgCoinRandom.Count; i++)
        {

            ListImgCoinRandom[i].transform.localPosition = Vector3.zero + new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0);
            ListImgCoinRandom[i].gameObject.SetActive(true);


            if (DOTween.IsTweening(ListImgCoinRandom[i].transform))
            {
                DOTween.Kill(ListImgCoinRandom[i].transform);
            }

            ListImgCoinRandom[i].transform.localScale = Vector3.zero;
            ListImgCoinRandom[i].transform.DOScale(1, 1f);
        }

        yield return BetterWaitForSeconds.Wait(.25f);

        if (!DOTween.IsTweening(btnCollect.transform))
            btnCollect.transform.DOScale(1.15f, .8f).SetEase(Ease.InQuad).SetLoops(10, LoopType.Yoyo);
        else
            DOTween.Kill(btnCollect.transform);

        for (int i = 0; i < ListImgCoinRandom.Count; i++)
        {
            ListImgCoinRandom[i].transform.DOMove(imgCoinBase.transform.position, .5f).SetEase(Ease.InOutBack).SetDelay(i * .15f);
        }

    }

    void MarginArrowAnimation()
    {
        objMarginArrow.transform.localEulerAngles = new Vector3(0, 0, 25);
        _calculator = true;
        imgMarginSlider.gameObject.SetActive(true);
        objMarginArrow.transform.DOLocalRotate(new Vector3(0, 0, -25), 1f).SetLoops(-1, LoopType.Yoyo);

    }
    int MarginCalculate(float _xEuler)
    {
        int _margin;
        if (_xEuler > 17 && _xEuler < 30 || _xEuler < 343 && _xEuler > 325)
        {
            _margin = 2;
        }

        else if (_xEuler > 5 && _xEuler < 17 || _xEuler > 343 && _xEuler < 355)
        {
            _margin = 3;
        }

        else
        {
            _margin = 5;
        }

        return _margin;
    }



}
