using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;

public class scr_StartArea : Singleton<scr_StartArea>
{
    [SerializeField] List<GameObject> listObjectHuni;  
    [SerializeField] List<GameObject> listObjectKilit;  

    int randomNo;
    private void Start()
    {
        randomNo = Random.Range(0, listObjectHuni.Count);
        listObjectHuni[randomNo].SetActive(true);
    }

    public void DropTheCup()
    {
        EventManager.Instance.StartTheGame();

        listObjectKilit[randomNo].transform.DOScale(Vector3.zero,.1f)
            .OnComplete(()=> listObjectKilit[randomNo].SetActive(false));
    }
}
