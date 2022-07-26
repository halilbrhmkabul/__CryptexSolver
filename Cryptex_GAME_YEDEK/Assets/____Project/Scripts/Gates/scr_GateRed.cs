using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_GateRed : MonoBehaviour
{
    [SerializeField] int RedCount;
    [SerializeField] TextMeshPro textRedCount;
    bool isTriggered;

    private void Start()
    {
        textRedCount.text = "-" + RedCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && GameManager.Instance.GameActive && other.CompareTag("tag_Ball"))
        {
            isTriggered = true; 
            scr_BallPool.Instance.CallBallSizeDown(RedCount);
        }
    }
}
