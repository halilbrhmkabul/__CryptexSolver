using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class scr_BallPool : Singleton<scr_BallPool>
{
    [Title("Pool Options")]
    public List<GameObject> ballObject;
    public List<GameObject> poolBallObjects;

    [SerializeField] float poolWaitTime;

    private GameObject createdObject;
    int ballCount;
    int counter = 0;


    void Start()
    {
        for (int j = 0; j < ballObject.Count; j++)
        {
            for (int i = 0; i < scr_LevelManager.Instance.BallSize; i++)
            {
                createdObject = Instantiate(ballObject[counter++ % ballObject.Count], Vector3.zero + new Vector3((UnityEngine.Random.Range(-.5f, .5f)), (UnityEngine.Random.Range(0, 2f)), (0)), Quaternion.identity, transform);
                poolBallObjects.Add(createdObject);
                createdObject.SetActive(false);
                createdObject.transform.localPosition = Vector3.zero;

            }
        }
        CallBallSize();
    }

    public void CallBallSize()
    {
        StartCoroutine(CallBall());
    }
    IEnumerator CallBall()
    {
        yield return new WaitForSeconds(poolWaitTime);

        if (ballCount < poolBallObjects.Count)
        {
            poolBallObjects[ballCount].SetActive(true);
        }
        else
        {
            yield return null;
        }
        ballCount++;
        if (ballCount < scr_LevelManager.Instance.BallSizeSpawn)
        {
            StartCoroutine(CallBall());
        }
        else
        {
            scr_PlayerController.Instance.WaitTheBalls = false;
        }
    }

    public void CallBallSizeDown(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            poolBallObjects[0].gameObject.SetActive(false);
            poolBallObjects.RemoveAt(0);
        }
    }
}