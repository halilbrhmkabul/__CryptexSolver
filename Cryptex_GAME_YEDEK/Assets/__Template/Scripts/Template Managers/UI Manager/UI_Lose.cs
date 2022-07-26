using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;
using DG.Tweening;  
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class UI_Lose : MonoBehaviour
{
    [Title("Panel Lose")]
    [SerializeField] GameObject panelLose;
    [SerializeField] RectTransform imgLose;
    [SerializeField] TextMeshProUGUI textLose;


    private void OnEnable()
    {
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
    }



    void GameLose(int gainedCoin)
    {
        textLose.transform.localScale = Vector3.zero;

        imgLose.transform.localPosition = new Vector3(0, (UI__Manager.Instance.MainCanvasScaler.referenceResolution.y / 2), 0);
        panelLose.SetActive(true);
        imgLose.transform.DOLocalMoveY((UI__Manager.Instance.MainCanvasScaler.referenceResolution.y / 2) - imgLose.rect.height, .5f);
        textLose.transform.DOScale(Vector3.one, 1f).SetDelay(.5f);

    }

    void LoadLevel()
    {
        panelLose.SetActive(false);
    } 
}
