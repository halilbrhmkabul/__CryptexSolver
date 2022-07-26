using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Tutorial : MonoBehaviour
{
    [SerializeField] GameObject objSeqOne, objSeqTwo;
    bool UpdateOpen;
    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnStartTheGame += StartTheGame;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnStartTheGame -= StartTheGame;
    }


    void TapToPlay()
    {
        objSeqOne.SetActive(true);
    }

    void StartTheGame()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.GameActive && !UpdateOpen)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30) && Input.GetMouseButton(0))
            {
                if (hit.collider.gameObject.tag.Equals("Layer0"))
                {
                    UpdateOpen = true;
                    objSeqOne.SetActive(false);
                    objSeqTwo.SetActive(true);
                }
            }
        }
    }
}
