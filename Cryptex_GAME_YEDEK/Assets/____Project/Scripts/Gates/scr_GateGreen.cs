using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scr_GateGreen : MonoBehaviour
{
    [SerializeField] int GreenCount;
    [SerializeField] TextMeshPro textGreenCount;
    bool isTriggered;

    private void Start()
    {
        textGreenCount.text = "+" + GreenCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && GameManager.Instance.GameActive && other.CompareTag("tag_Ball"))
        { 
            isTriggered = true;
            scr_LevelManager.Instance.BallSizeSpawn += GreenCount;
            scr_BallPool.Instance.CallBallSize();
        }
    }
}
