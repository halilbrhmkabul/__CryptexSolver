//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Pixelplacement;
//using TMPro;
//using DG.Tweening;
//using MoreMountains.NiceVibrations;
//using MoreMountains.Feedbacks;
//using UnityEngine.SceneManagement;
//using Sirenix.OdinInspector;

//public class UIManager : Singleton<UIManager>
//{
//    #region UI Elements
//    #region Panel Game

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelGameHide;
//    [HideIfGroup("PanelGameHide")]

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] Image panelGame;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] GameObject imgCoin;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] List<Image> imgCoinInGameRandom;
//    GameObject imgCoinOBJ; float imgCoinWaitTime;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] GameObject imgCoinBase;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] GameObject imgLevel;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] TextMeshProUGUI textCoin;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    [SerializeField] TextMeshProUGUI textLevel;

//    [BoxGroup("PanelGameHide/Panel Game Inspector")]
//    public int level, coin;

//    #endregion

//    #region Panel Start

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelStartHide;
//    [HideIfGroup("PanelStartHide")]

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image panelStart;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Button btnStart;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] TextMeshProUGUI textStart;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Button btnSound;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image imgSoundON;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image imgSoundOFF;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    bool soundState;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Button btnVibrate;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image imgVibrateON;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image imgVibrateOFF;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    bool vibrateState;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Button btnSetting;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    [SerializeField] Image imgSettingIcon;

//    [BoxGroup("PanelStartHide/Panel Start Inspector")]
//    bool settingState;

//    #endregion

//    #region Panel Win

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelWinHide;
//    [HideIfGroup("PanelWinHide")]

//    [BoxGroup("PanelWinHide/Panel Win Inspector")]
//    [SerializeField] Image panelWin;

//    [BoxGroup("PanelWinHide/Panel Win Inspector")]
//    [SerializeField] Image imgWin;

//    [BoxGroup("PanelWinHide/Panel Win Inspector")]
//    [SerializeField] TextMeshProUGUI textWin;

//    [BoxGroup("PanelWinHide/Panel Win Inspector")]
//    [SerializeField] string[] textWinArray;
//    #endregion

//    #region Panel Lose
//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelLoseHide;

//    [HideIfGroup("PanelLoseHide")]
//    [BoxGroup("PanelLoseHide/Panel Lose Inspector")]
//    [SerializeField] Image panelLose;

//    #endregion

//    #region Panel Market
//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelMarketHide;

//    [HideIfGroup("PanelMarketHide")]
//    [BoxGroup("PanelMarketHide/Panel Market Inspector")]
//    [SerializeField] Image panelMarket;
//    #endregion

//    #region Panel Rewards

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelRewardsHide;

//    [HideIfGroup("PanelRewardsHide")]
//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] Image panelRewards;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] Button btnLoadLevel;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] TextMeshProUGUI textLoadLevel;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] Button btnCollect;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] TextMeshProUGUI textCollect;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] GameObject objCoinRandom;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] List<Image> imgCoinRandom;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] Image panelRewardsBackground;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] float panelRewardWaitTime;

//    [BoxGroup("PanelRewardsHide/Panel Rewards Inspector")]
//    [SerializeField] List<Image> imgRewardBG;

//    #endregion

//    #region Panel Tutorials 
//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool PanelTutorialsHide;

//    [HideIfGroup("PanelTutorialsHide")]
//    [BoxGroup("PanelTutorialsHide/Panel Rewards Inspector")]
//    [SerializeField] Image panelTutorial;

//    [BoxGroup("PanelTutorialsHide/Panel Rewards Inspector")]
//    [SerializeField] Image tutorialSwerve;

//    [BoxGroup("PanelTutorialsHide/Panel Rewards Inspector")]
//    [SerializeField] Image tutorialIdle;
//    #endregion



//    #region UI Mode Filled Animation

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    public bool UiMode;

//    [HideIfGroup("UiMode")]
//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] bool isActiveFilledAnimationUI;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] GameObject objFilledAnimation;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] Image imgFilledEmpty;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] Image imgFilledFull;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] TextMeshProUGUI textFilledImagePercent;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] List<Sprite> listFilledSpriteEmpty;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    [SerializeField] List<Sprite> listFilledSpriteFull;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    int _calculatedImageFilledText;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    int _calculatedImageIndex;

//    [BoxGroup("UiMode/UI Mode: Filled Animation")]
//    int _calculatedImageFilledIndex;

//    #endregion

//    #region UI Mode Margin Arrow

//    [BoxGroup("UiMode/UI Mode: Margin Arrow")]
//    [SerializeField] bool isActiveMarginArrowUI;

//    [BoxGroup("UiMode/UI Mode: Margin Arrow")]
//    [SerializeField] Image imgMarginSlider;

//    [BoxGroup("UiMode/UI Mode: Margin Arrow")]
//    [SerializeField] GameObject objMarginArrow;

//    [BoxGroup("UiMode/UI Mode: Margin Arrow")]
//    float _eulerX;

//    [BoxGroup("UiMode/UI Mode: Margin Arrow")]
//    bool _calculator;
//    #endregion

//    #region UI Mode Panel Developer
//    [BoxGroup("UiMode/UI Mode: Panel Developer")]
//    [SerializeField] bool isPanelDeveloperActive;

//    [BoxGroup("UiMode/UI Mode: Panel Developer")]
//    [SerializeField] Image panelDeveloper;
//    #endregion

//    #region Other Options

//    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
//    [Title("Other Options")]
//    [SerializeField] float _coinImageAnimationTime = .5f;
//    [SerializeField] float coinTextTime = .009f;
//    [SerializeField] float coinTextAnimationTime = .004f;
//    [SerializeField] MMFeedbacks mmFeedbackScript;
//    #endregion
//    #endregion

//    #region Delegates - Events
//    private void OnEnable()
//    {
//        EventManager.Instance.OnTapToPlay += TapToPlay;
//        EventManager.Instance.OnLoadLevel += LoadLevel;
//        EventManager.Instance.OnGameLose += GameLose;
//        EventManager.Instance.OnGameWin += GameWin;
//        EventManager.Instance.OnJustGainCoin += JustGainCoin;
//    }
//    private void OnDisable()
//    {
//        EventManager.Instance.OnTapToPlay -= TapToPlay;
//        EventManager.Instance.OnLoadLevel -= LoadLevel;
//        EventManager.Instance.OnGameLose -= GameLose;
//        EventManager.Instance.OnGameWin -= GameWin;
//        EventManager.Instance.OnJustGainCoin -= JustGainCoin;
//    }
//    void TapToPlay()
//    {
//        #region TapToPlayAnimations

//        imgLevel.gameObject.SetActive(true);
//        textStart.gameObject.SetActive(false);
//        panelStart.enabled = false;
//        btnStart.gameObject.SetActive(false);


//        panelStart.transform.DOLocalMoveX(-Screen.width, 2.5f)
//            .OnComplete(() =>
//            {
//                panelStart.gameObject.SetActive(false);
//                panelStart.transform.localPosition = Vector3.zero;
//                panelStart.enabled = true;
//                textStart.gameObject.SetActive(true);
//                btnStart.gameObject.SetActive(true);
//            });



//        #endregion

//    }
//    void LoadLevel()
//    {
//        GameUILoad();
//    }
//    void GameLose(int GainedCoin)
//    {
//        if (GainedCoin != 0)
//        {
//            btnCollect.gameObject.SetActive(true);
//            textCollect.text = GainedCoin.ToString();
//            coin = PlayerPrefs.GetInt("coin");

//            PlayerPrefs.SetInt("coin", (coin + GainedCoin));

//            textLoadLevel.text = "No, thanks...";



//            StartCoroutine(RewardBackgroundAnimation(false, GainedCoin, panelRewardWaitTime));


//        }

//        else
//        {
//            LoseScreenAnimation();
//        }



//    }
//    void GameWin(int GainedCoin)
//    {
//        GetPlayerPrefs();

//        PlayerPrefs.SetInt("level", ++level);
//        PlayerPrefs.SetInt("coin", (coin + GainedCoin));

//        btnCollect.gameObject.SetActive(true);
//        textCollect.text = "3x";
//        btnLoadLevel.gameObject.SetActive(true);
//        textLoadLevel.text = "No, thanks...";

//        StartCoroutine(RewardBackgroundAnimation(true, GainedCoin, panelRewardWaitTime));




//    }
//    void JustGainCoin(int GainedCoin, Vector3 WorldPos)
//    {
//        GetPlayerPrefs();

//        PlayerPrefs.SetInt("coin", (coin + GainedCoin));
//        CoinTextFullAnimation(coin, (coin + GainedCoin));
//        CoinAnimationInGame(WorldPos);
//    }

//    #endregion

//    #region Buttons
//    public void GameStart()
//    {
//        EventManager.Instance.TapToPlay();

//    }
//    public void MarketOnOff()
//    {
//        if (panelMarket.gameObject.activeInHierarchy)
//        {
//            panelMarket.gameObject.SetActive(false);
//            return;
//        }
//        if (!panelMarket.gameObject.activeInHierarchy)
//        {
//            panelMarket.gameObject.SetActive(true);
//            return;
//        }

//    }
//    public void SettingsOnOff()
//    {
//        if (!DOTween.IsTweening(imgSettingIcon.transform))
//        {
//            if (settingState)
//            {
//                settingState = false;

//                btnVibrate.transform.DOLocalMoveY(btnSetting.transform.localPosition.y, .5f)
//                        .OnComplete(() => btnVibrate.gameObject.SetActive(false));

//                btnSound.transform.DOLocalMoveY(btnSetting.transform.localPosition.y, .5f)
//                    .OnComplete(() => btnSound.gameObject.SetActive(false));

//                imgSettingIcon.transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
//            }
//            else
//            {
//                settingState = true;

//                btnVibrate.gameObject.SetActive(true);
//                btnVibrate.transform.DOLocalMoveY(btnSetting.transform.localPosition.y - 240, .5f);

//                btnSound.gameObject.SetActive(true);
//                btnSound.transform.DOLocalMoveY(btnSetting.transform.localPosition.y - 115, .5f);

//                imgSettingIcon.transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
//            }
//        }
//    }
//    public void VibrateOnOff()
//    {
//        if (vibrateState)
//        {
//            vibrateState = false;
//            MMVibrationManager._vibrationsActive = false;
//            PlayerPrefs.SetInt("vibrate", 1);
//            imgVibrateON.gameObject.SetActive(false);
//            imgVibrateOFF.gameObject.SetActive(true);
//        }
//        else
//        {
//            vibrateState = true;
//            MMVibrationManager._vibrationsActive = true;
//            PlayerPrefs.SetInt("vibrate", 0);
//            imgVibrateOFF.gameObject.SetActive(false);
//            imgVibrateON.gameObject.SetActive(true);
//        }
//    }
//    public void SoundOnOff()
//    {
//        if (soundState)
//        {
//            soundState = false;
//            PlayerPrefs.SetInt("sound", 1);
//            imgSoundON.gameObject.SetActive(false);
//            imgSoundOFF.gameObject.SetActive(true);
//            AudioListener.pause = true;
//        }
//        else
//        {
//            soundState = true;
//            PlayerPrefs.SetInt("sound", 0);
//            imgSoundON.gameObject.SetActive(true);
//            imgSoundOFF.gameObject.SetActive(false);
//            AudioListener.pause = false;
//        }

//    }
//    public void NextOrRestartLevel()
//    {
//        btnLoadLevel.enabled = false;
//        mmFeedbackScript?.PlayFeedbacks();
//        StartCoroutine(waitFinishFader());
//    }
//    public void CollectMargin()
//    {
//        textLoadLevel.text = "Let's go!";
//        btnCollect.enabled = false;
//        _coinImageAnimationTime = .5f;

//        if (isActiveMarginArrowUI)
//        {
//            _calculator = false;
//            int coinCollected = MarginCalculate(objMarginArrow.transform.localEulerAngles.z);
//            DOTween.Kill(objMarginArrow.transform);
//            EventManager.Instance.JustGainCoin(coin * coinCollected, Vector3.zero);
//        }
//        else
//        {
//            EventManager.Instance.JustGainCoin(coin * 2, Vector3.zero);

//        }

//        StartCoroutine(CoinImageAnimation(0));
//    }
//    #endregion

//    #region Functions
//    void GameUILoad()
//    {

//        #region PanelPlayerPrefsGet
//        if (PlayerPrefs.GetInt("vibrate") == 0)
//        {
//            vibrateState = true;
//            MMVibrationManager._vibrationsActive = true;
//            imgVibrateON.gameObject.SetActive(true);
//            imgVibrateOFF.gameObject.SetActive(false);

//        }
//        else
//        {
//            vibrateState = false;
//            MMVibrationManager._vibrationsActive = false;
//            imgVibrateOFF.gameObject.SetActive(true);
//            imgVibrateON.gameObject.SetActive(false);
//        }

//        if (PlayerPrefs.GetInt("sound") == 0)
//        {
//            soundState = true;
//            imgSoundON.gameObject.SetActive(true);
//            imgSoundOFF.gameObject.SetActive(false);
//            AudioListener.pause = false;
//        }

//        else
//        {
//            soundState = false;
//            imgSoundON.gameObject.SetActive(false);
//            imgSoundOFF.gameObject.SetActive(true);
//            AudioListener.pause = true;
//        }

//        GetPlayerPrefs();
//        textLevel.SetText(level + 1, "Level ", null);
//        textCoin.SetText(coin);
//        #endregion

//        #region FirstOpenPanelStatesSet
//        panelLose.gameObject.SetActive(false);
//        panelWin.gameObject.SetActive(false);
//        panelMarket.gameObject.SetActive(false);
//        panelRewardsBackground.gameObject.SetActive(false);
//        panelStart.gameObject.SetActive(true);
//        panelGame.gameObject.SetActive(true);
//        imgLevel.gameObject.SetActive(true);


//        panelGame.transform.localPosition = Vector3.zero;
//        panelStart.transform.localPosition = Vector3.zero;
//        panelLose.transform.localPosition = Vector3.zero + new Vector3(0, Screen.height, 0);
//        panelWin.transform.localPosition = Vector3.zero + new Vector3(0, Screen.height, 0);

//        imgRewardBG[0].transform.localPosition = new Vector3(-imgRewardBG[0].preferredWidth, 0, 0);
//        imgRewardBG[1].transform.localPosition = new Vector3(imgRewardBG[0].preferredWidth, 0, 0);
//        imgRewardBG[2].transform.localPosition = new Vector3(-imgRewardBG[0].preferredWidth, 0, 0);
//        imgRewardBG[3].transform.localPosition = new Vector3(imgRewardBG[0].preferredWidth, 0, 0);

//        for (int i = 0; i < imgRewardBG.Count; i++)
//            imgRewardBG[i].gameObject.SetActive(false);


//        for (int i = 0; i < imgCoinInGameRandom.Count; i++)
//            imgCoinInGameRandom[i].transform.localPosition = Vector3.zero;


//        imgLevel.gameObject.SetActive(true);
//        btnStart.gameObject.SetActive(true);
//        textStart.gameObject.SetActive(true);

//        btnCollect.enabled = true;
//        objCoinRandom.SetActive(false);
//        imgMarginSlider.gameObject.SetActive(false);
//        panelRewards.gameObject.SetActive(false);
//        _coinImageAnimationTime = .5f;
//        objFilledAnimation.gameObject.SetActive(false);
//        btnLoadLevel.enabled = true;
//        textCoin.transform.localScale = new Vector3(1, 1, 1);
//        textFilledImagePercent.transform.localScale = new Vector3(1, 1, 1);
//        imgCoinWaitTime = 0;


//        if (isPanelDeveloperActive)
//            panelDeveloper.gameObject.SetActive(true);


//        if (level == 0)
//        {
//            panelTutorial.gameObject.SetActive(true);
//        }

//        #endregion

//        textLevel.transform.DOScale(1.25f, 0.5f).SetLoops(2, LoopType.Yoyo);

//    }

//    void CoinTextFullAnimation(int firstVariable, int endVariable)
//    {
//        textCoin.transform.DOScale(1.25f, coinTextAnimationTime)
//         .OnStepComplete(() =>
//         {
//             firstVariable++;
//             textCoin.SetText(firstVariable);
//         }).SetLoops(endVariable - firstVariable)
//         .OnComplete(() => textCoin.transform.DOScale(1f, coinTextAnimationTime));
//    }
//    IEnumerator CoinImageAnimation(int index)
//    {
//        if (index == 0)
//        {
//            //-------------------- Coin Animation
//            objCoinRandom.SetActive(true);
//            for (int i = 0; i < imgCoinRandom.Count; i++)
//            {

//                imgCoinRandom[i].transform.localPosition = Vector3.zero + new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0);
//                imgCoinRandom[i].gameObject.SetActive(true);


//                if (DOTween.IsTweening(imgCoinRandom[i].transform))
//                {
//                    DOTween.Kill(imgCoinRandom[i].transform);
//                }

//                imgCoinRandom[i].transform.localScale = Vector3.zero;
//                imgCoinRandom[i].transform.DOScale(0.68521f, 1f);
//            }

//            yield return BetterWaitForSeconds.Wait(.5f);

//        }



//        if (index < imgCoinRandom.Count)
//        {
//            imgCoinRandom[index].transform.DOMove(imgCoinBase.transform.position, _coinImageAnimationTime).SetEase(Ease.InOutBack);
//            index++;
//            _coinImageAnimationTime += .3f;
//            if (index != imgCoinRandom.Count)
//            {
//                StartCoroutine(CoinImageAnimation(index));
//            }
//            else
//            {

//                btnCollect.transform.DOScale(1.15f, .8f).SetEase(Ease.InQuad).SetLoops(10, LoopType.Yoyo); ;
//                yield return null;
//            }
//        }

//    }

//    void CoinAnimationInGame(Vector3 WorldPos)
//    {
//        if (GameManager.Instance.GameActive)
//        {
//            imgCoinOBJ = imgCoinInGameRandom[0].gameObject;

//            if (!DOTween.IsTweening(imgCoinOBJ.transform))
//            {
//                imgCoinInGameRandom.RemoveAt(0);
//                imgCoinInGameRandom.Add(imgCoinOBJ.GetComponent<Image>());

//                imgCoinOBJ.transform.position = WorldPos;


//                imgCoinOBJ.transform.DOMove(imgCoinBase.transform.position, 1f).SetDelay(imgCoinWaitTime).SetEase(Ease.InBack)
//                    .OnComplete(() => { imgCoinWaitTime = 0; });
//                imgCoinWaitTime += .1f;
//            }
//        }
//    }

//    void FilledImageAnimation()
//    {
//        if (isActiveFilledAnimationUI && (listFilledSpriteEmpty.Count == listFilledSpriteFull.Count))
//        {
//            objFilledAnimation.SetActive(true);
//            imgFilledEmpty.gameObject.SetActive(true);
//            imgFilledFull.gameObject.SetActive(true);
//            textFilledImagePercent.gameObject.SetActive(true);
//            imgFilledFull.fillAmount = 0;
//            _calculatedImageFilledText = 0;
//            _calculatedImageIndex = (level - 1) / 5;

//            if (_calculatedImageIndex > listFilledSpriteEmpty.Count - 1)
//            {
//                _calculatedImageIndex = listFilledSpriteEmpty.Count - 1;
//            }

//            _calculatedImageFilledIndex = (level) % 5;


//            if (_calculatedImageFilledIndex == 0)
//            {
//                if ((level - 1) % 5 >= 4)
//                {
//                    _calculatedImageFilledIndex = 5;
//                }

//            }

//            imgFilledEmpty.sprite = listFilledSpriteEmpty[_calculatedImageIndex];
//            imgFilledFull.sprite = listFilledSpriteFull[_calculatedImageIndex];

//            imgFilledFull.DOFillAmount(((_calculatedImageFilledIndex * 20) * .01f), 1f);


//            textFilledImagePercent.transform.DOScale(1.25f, coinTextTime)
//                    .OnStepComplete(() =>
//                    {
//                        _calculatedImageFilledText++;
//                        textFilledImagePercent.SetText((_calculatedImageFilledText), null, "%");
//                    }).SetLoops((_calculatedImageFilledIndex * 20) - _calculatedImageFilledText)
//                    .OnComplete(() => textFilledImagePercent.transform.DOScale(1f, coinTextTime));


//        }

//    }

//    IEnumerator RewardBackgroundAnimation(bool WinOrLose, int GainedCoin, float waitTime)
//    {
//        yield return BetterWaitForSeconds.WaitRealtime(waitTime);
//        btnCollect.gameObject.SetActive(true);

//        panelRewardsBackground.gameObject.SetActive(true);
//        panelGame.transform.DOLocalMoveY(Screen.height, 1f);

//        panelRewards.transform.localScale = new Vector3(0, 0, 0);
//        panelRewards.gameObject.SetActive(true);

//        int no = 0;
//        if (WinOrLose == false)
//            no = 2;

//        imgRewardBG[no].gameObject.SetActive(true);
//        imgRewardBG[no].transform.DOLocalMoveX(0, .5f);
//        imgRewardBG[no + 1].gameObject.SetActive(true);
//        imgRewardBG[no + 1].transform.DOLocalMoveX(0, .5f)
//    .OnComplete(() =>
//    {



//        if (WinOrLose)
//        {
//            imgLevel.gameObject.SetActive(false);
//            panelWin.gameObject.SetActive(true);

//            textWin.SetText(textWinArray[Random.Range(0, textWinArray.Length)]);





//            panelGame.transform.DOLocalMoveY(0, 1.25f).SetEase(Ease.InOutBack);
//            panelWin.transform.DOLocalMoveY(0, 1f).SetEase(Ease.InOutBack)
//            .OnComplete(() =>
//            {
//                for (int i = 0; i < imgCoinInGameRandom.Count; i++)
//                {
//                    imgCoinInGameRandom[i].transform.localPosition = Vector3.zero;
//                }

//                _coinImageAnimationTime = .5f;


//                if (isActiveMarginArrowUI) MarginArrowAnimation();
//                if (isActiveFilledAnimationUI) FilledImageAnimation();

//                panelRewards.transform.DOScale(Vector3.one, .9f).SetEase(Ease.OutBack);


//                //imgWin.transform.DOScale(1.1f, 1f).SetLoops(15, LoopType.Yoyo).SetEase(Ease.InOutQuad);

//                CoinTextFullAnimation(coin, (coin + GainedCoin));
//                StartCoroutine(CoinImageAnimation(0));

//                coin = GainedCoin;
//            });
//        }
//        else
//        {
//            panelLose.gameObject.SetActive(true);


//            panelGame.transform.DOLocalMoveY(0, 1.55f).SetEase(Ease.InOutBack);
//            panelLose.transform.DOLocalMoveY(0, 1f).SetEase(Ease.InOutBack)
//            .OnComplete(() =>
//            {
//                panelRewards.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);


//                for (int i = 0; i < imgCoinInGameRandom.Count; i++)
//                {
//                    imgCoinInGameRandom[i].transform.localPosition = Vector3.zero;
//                }


//                CoinTextFullAnimation(coin, (coin + GainedCoin));
//                StartCoroutine(CoinImageAnimation(0));
//                coin = GainedCoin;

//                if (isActiveMarginArrowUI) MarginArrowAnimation();


//                _coinImageAnimationTime = .5f;

//                btnLoadLevel.gameObject.SetActive(true);


//            });

//            // panelLose.transform.DOScale(1.15f, 2f).OnComplete(() => panelLose.transform.DOScale(1f, 1f));
//        }
//    });
//    }

//    void LoseScreenAnimation()
//    {
//        btnCollect.gameObject.SetActive(false);

//        panelRewardsBackground.gameObject.SetActive(true);
//        panelGame.transform.DOLocalMoveY(Screen.height, 1f);

//        panelRewards.transform.localScale = new Vector3(0, 0, 0);
//        panelRewards.gameObject.SetActive(true);

//        textLoadLevel.text = "Try Again...";

//        int no = 2;

//        imgRewardBG[no].gameObject.SetActive(true);
//        imgRewardBG[no + 1].gameObject.SetActive(true);

//        imgRewardBG[no].transform.DOLocalMoveX(0, .5f);
//        imgRewardBG[no + 1].transform.DOLocalMoveX(0, .5f).OnComplete(() =>
//        {



//            panelLose.gameObject.SetActive(true);

//            panelRewards.transform.DOScale(Vector3.one, .9f).SetEase(Ease.OutBack);
//            panelGame.transform.DOLocalMoveY(0, 1.25f).SetEase(Ease.InOutBack);
//            panelLose.transform.DOLocalMoveY(0, 1f).SetEase(Ease.InOutBack)
//            .OnComplete(() =>
//            {

//                for (int i = 0; i < imgCoinInGameRandom.Count; i++)
//                {
//                    imgCoinInGameRandom[i].transform.localPosition = Vector3.zero;
//                }




//                _coinImageAnimationTime = .5f;

//                btnLoadLevel.gameObject.SetActive(true);


//            });




//        });


//    }
//    void MarginArrowAnimation()
//    {
//        objMarginArrow.transform.localEulerAngles = new Vector3(0, 0, 25);
//        _calculator = true;
//        imgMarginSlider.gameObject.SetActive(true);
//        objMarginArrow.transform.DOLocalRotate(new Vector3(0, 0, -25), 1f).SetLoops(-1, LoopType.Yoyo);

//    }
//    int MarginCalculate(float _xEuler)
//    {
//        int _margin;
//        if (_xEuler > 17 && _xEuler < 30 || _xEuler < 343 && _xEuler > 325)
//        {
//            _margin = 2;
//        }

//        else if (_xEuler > 5 && _xEuler < 17 || _xEuler > 343 && _xEuler < 355)
//        {
//            _margin = 3;
//        }

//        else
//        {
//            _margin = 5;
//        }

//        return _margin;
//    }
//    void GetPlayerPrefs()
//    {
//        level = PlayerPrefs.GetInt("level");
//        coin = PlayerPrefs.GetInt("coin");
//    }

//    private void Update()
//    {
//        if (isActiveMarginArrowUI && _calculator)
//        {
//            _eulerX = objMarginArrow.transform.localEulerAngles.z;
//            textCollect.SetText((MarginCalculate(_eulerX) * coin));
//        }
//    }
//    IEnumerator waitFinishFader()
//    {
//        yield return BetterWaitForSeconds.Wait(.75f);
//        GameManager.Instance.StateMachineGame.ChangeState(4);
//    }
//    #endregion
//}