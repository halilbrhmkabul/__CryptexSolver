using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;
using DG.Tweening;  
using Sirenix.OdinInspector;

public class UI_Game : Singleton<UI_Game>
{
    [Title("Panel Game")]
    [SerializeField] GameObject panelGame;
    [SerializeField] Image imgLevel;
    [SerializeField] TextMeshProUGUI textLevel;
    [SerializeField] TextMeshProUGUI textCoin;

    [Title("Settings")]
    [SerializeField] Button btnSetting;
    [SerializeField] Image imgSettingIcon;
    bool settingState;

    [Title("Sound")]
    [SerializeField] Button btnSound;
    [SerializeField] Image imgSoundON;
    [SerializeField] Image imgSoundOFF;
    bool soundState;

    [Title("Haptic")]
    [SerializeField] Button btnHaptic;
    [SerializeField] Image imgHapticON;
    [SerializeField] Image imgHapticOFF;
    bool hapticState;


    [Title("Coin Image")]
    [SerializeField] GameObject imgCoinRandom;
    [SerializeField] Image imgCoinBase;
    [SerializeField] List<Image> ListImgCoinRandom;


    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnLoadLevel += LoadLevel;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGainCoin += GainCoin;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGainCoin -= GainCoin;
    }

    void TapToPlay()
    {
        imgLevel.gameObject.SetActive(false);
    }

    void LoadLevel()
    {
        DataManager.Instance.GetPlayerPrefs();
        imgLevel.gameObject.SetActive(true);

        LoadUI();
    }

    void GameLose(int gainedCoin)
    {
        imgLevel.gameObject.SetActive(true);
        CoinTextAnimation(DataManager.Instance.Coin, DataManager.Instance.Coin + gainedCoin);
    }

    void GameWin(int gainedCoin)
    {
        imgLevel.gameObject.SetActive(true);
        CoinTextAnimation(DataManager.Instance.Coin, DataManager.Instance.Coin + gainedCoin);
    }

    void GainCoin(int gainedCoin, Vector3 worldPos)
    { 
        CoinTextAnimation(DataManager.Instance.Coin, DataManager.Instance.Coin + gainedCoin);
        CoinImageAnimationInPanelGame(worldPos);
        DataManager.Instance.SetPlayerPrefsCoin(gainedCoin);
    }

 

    void LoadUI()
    {
        panelGame.SetActive(true);

        if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundState = true;
            imgSoundON.gameObject.SetActive(true);
            imgSoundOFF.gameObject.SetActive(false);
            AudioListener.pause = false;
        }

        else
        {
            soundState = false;
            imgSoundON.gameObject.SetActive(false);
            imgSoundOFF.gameObject.SetActive(true);
            AudioListener.pause = true;
        }

        if (PlayerPrefs.GetInt("haptic") == 0)
        {
            hapticState = true;
            imgHapticON.gameObject.SetActive(true);
            imgHapticOFF.gameObject.SetActive(false);
            //MMVibrationManager._vibrationsActive = true;
            Vibration.HapticActive = true;
        }
        else
        {
            hapticState = false;
            imgHapticON.gameObject.SetActive(false);
            imgHapticOFF.gameObject.SetActive(true);
            //MMVibrationManager._vibrationsActive = false;
            Vibration.HapticActive = false;
        }


        textLevel.text = "Level " + DataManager.Instance.Level.ToString();
        textLevel.transform.localScale = Vector3.one;

        textCoin.text = DataManager.Instance.Coin.ToString();
        textCoin.transform.localScale = Vector3.one;

        imgLevel.gameObject.SetActive(true);
    }




    public void SettingsOnOff()
    {
        if (!DOTween.IsTweening(imgSettingIcon.transform))
        {
            if (settingState)
            {
                settingState = false;

                btnHaptic.transform.DOLocalMoveY(btnSetting.transform.localPosition.y, .5f)
                        .OnComplete(() => btnHaptic.gameObject.SetActive(false));

                btnSound.transform.DOLocalMoveY(btnSetting.transform.localPosition.y, .5f)
                    .OnComplete(() => btnSound.gameObject.SetActive(false));

                imgSettingIcon.transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
            }
            else
            {
                settingState = true;

                btnHaptic.gameObject.SetActive(true);
                btnHaptic.transform.DOLocalMoveY(btnSetting.transform.localPosition.y - 185, .5f);

                btnSound.gameObject.SetActive(true);
                btnSound.transform.DOLocalMoveY(btnSetting.transform.localPosition.y - 95, .5f);

                imgSettingIcon.transform.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
            }
        }
    }
    public void HapticOnOff()
    {
        if (hapticState)
        {
            hapticState = false;
            //MMVibrationManager._vibrationsActive = hapticState;
            Vibration.HapticActive = hapticState;

            PlayerPrefs.SetInt("haptic", 1);
            imgHapticON.gameObject.SetActive(hapticState);
            imgHapticOFF.gameObject.SetActive(true);
        }
        else
        {
            hapticState = true;
            //MMVibrationManager._vibrationsActive = hapticState;
            Vibration.HapticActive = hapticState;
            PlayerPrefs.SetInt("haptic", 0);
            imgHapticON.gameObject.SetActive(hapticState);
            imgHapticOFF.gameObject.SetActive(false);

        }
    }
    public void SoundOnOff()
    {
        if (soundState)
        {
            soundState = false;
            PlayerPrefs.SetInt("sound", 1);
            imgSoundON.gameObject.SetActive(false);
            imgSoundOFF.gameObject.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            soundState = true;
            PlayerPrefs.SetInt("sound", 0);
            imgSoundON.gameObject.SetActive(true);
            imgSoundOFF.gameObject.SetActive(false);
            AudioListener.pause = false;
        }

    }

     


    void CoinImageAnimationInPanelGame(Vector3 WorldPos)
    {
        if (GameManager.Instance.GameActive)
        {
            imgCoinRandom = ListImgCoinRandom[0].gameObject;
            imgCoinRandom.gameObject.SetActive(true);

            if (!DOTween.IsTweening(imgCoinBase.transform))
            {
                ListImgCoinRandom.RemoveAt(0);
                ListImgCoinRandom.Add(imgCoinRandom.GetComponent<Image>());

                imgCoinRandom.transform.position = WorldPos;

                imgCoinRandom.transform.DOMove(imgCoinBase.transform.position, 1f).SetDelay(.1f).SetEase(Ease.InOutBack);
            }
        }
    }
    public void CoinTextAnimation(int firstVariable, int endVariable)
    {
        float textAnimationTimer = UI__Manager.Instance.TextAnimationTimer; ;


        if (DOTween.IsTweening(textCoin.transform))
            DOTween.Kill(textCoin.transform);

        if (firstVariable < endVariable)
        {
            textCoin.transform.DOScale(1.25f, textAnimationTimer)
             .OnStepComplete(() =>
             {
                 firstVariable++;
                 textCoin.text = firstVariable.ToString();
             }).SetLoops(endVariable - firstVariable)
             .OnComplete(() => textCoin.transform.DOScale(1f, textAnimationTimer));
        }
        else
        {
            textCoin.transform.DOScale(1.25f, textAnimationTimer)
        .OnStepComplete(() =>
        {
            firstVariable--;
            textCoin.text = firstVariable.ToString();
        }).SetLoops(firstVariable - endVariable)
        .OnComplete(() => textCoin.transform.DOScale(1f, textAnimationTimer));
        }


    }
}