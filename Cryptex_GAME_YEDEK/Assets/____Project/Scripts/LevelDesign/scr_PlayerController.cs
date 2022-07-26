using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pixelplacement;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Unity.Mathematics;


public class scr_PlayerController : Singleton<scr_PlayerController>
{
    public bool isTweening;
    private bool isRotate;

    private float _moveX;
    private Vector3 newRotate;
    private DG.Tweening.Tween rotateTween;
    public int CalculateDegree;

    public bool WaitTheBalls = true;
    public bool Controller= false;

    
    private void Start()
    {
        CalculateDegree = 360 / scr_LevelManager.Instance.LayerCount;
    }

    private void FixedUpdate() // KANKA FİXED YAPTIM AMA İSTERSEN UPDATE YAP ******************
    {
        HorizontalRotate();
    }

    void HorizontalRotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (GameManager.Instance.GameActive && !Controller)
        {
            if (Physics.Raycast(ray, out hit, 30) && Input.GetMouseButton(0) && !isTweening)
            {
                if (hit.collider.gameObject.tag.Equals("Layer0"))
                {
                    _moveX = Input.GetAxis("Mouse X");
                    if (_moveX < 0  )
                    {

                        isTweening = true;
                        newRotate += new Vector3(0, transform.rotation.y + CalculateDegree, 0);
                        rotateTween.Kill();
                        rotateTween = hit.collider.gameObject.transform.DORotate(newRotate, .5f).OnComplete(
                           () =>
                           {
                               isTweening = false;
                           }
                        );

                        if (isTweening)
                        {
                            Debug.Log(isTweening);
                        }

                    }

                    else if (_moveX > 0)
                    {

                        isTweening = true;
                        newRotate -= new Vector3(0, transform.rotation.y + CalculateDegree, 0);

                        rotateTween.Kill();
                        rotateTween = hit.collider.gameObject.transform.DORotate(newRotate, .5f).OnComplete(() =>

                        {
                            isTweening = false;
                        }
                           );
                        isRotate = true;

                    }


                }


            }


            if (Physics.Raycast(ray, out hit, 30) && Input.GetMouseButtonDown(0) && !isTweening && !WaitTheBalls)
            {
                if (hit.collider.gameObject.tag.Equals("tag_Huni"))
                {
                    scr_StartArea.Instance.DropTheCup();
                    Controller = true;
                }
            }
        }
    }




}
