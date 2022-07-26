using System.Collections.Generic;
using UnityEngine; 
using TMPro;
using DG.Tweening; 
using Sirenix.OdinInspector;

public class UI_Win : MonoBehaviour
{
    [Title("Panel Win")]
    [SerializeField] GameObject panelWin;
    [SerializeField] RectTransform imgWin;
    [SerializeField] TextMeshProUGUI textWin;

    [SerializeField] List<string> listWinText;


    private void OnEnable()
    {
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnLoadLevel += LoadLevel;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
    }



    void GameWin(int gainedCoin)
    {
        SetWinText();
    }

    void LoadLevel()
    {
        panelWin.SetActive(false);
    }
     

    int randomIndex;
    void SetWinText()
    {
        imgWin.transform.localPosition = new Vector3(0, (UI__Manager.Instance.MainCanvasScaler.referenceResolution.y / 2), 0);
        textWin.transform.localScale = Vector3.zero;

        panelWin.SetActive(true);
        imgWin.transform.DOLocalMoveY((UI__Manager.Instance.MainCanvasScaler.referenceResolution.y / 2) - imgWin.rect.height, .5f);

        randomIndex = Random.Range(0, listWinText.Count);
        textWin.text = listWinText[randomIndex];

        textWin.transform.DOScale(Vector3.one, 1f).SetDelay(.5f);  
    }
}
