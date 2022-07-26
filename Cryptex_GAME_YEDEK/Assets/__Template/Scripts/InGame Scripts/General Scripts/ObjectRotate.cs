using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ObjectRotate : MonoBehaviour
{
    [BoxGroup("Rotate Active")]
    [SerializeField] bool isRotating;

    [BoxGroup("Rotate Mode")]
    [SerializeField] RotateMode rotateMode;

    [BoxGroup("Rotate Value")]
    [SerializeField] float valueX;
    [BoxGroup("Rotate Value")]
    [SerializeField] float valueY;
    [BoxGroup("Rotate Value")]
    [SerializeField] float valueZ;

    [BoxGroup("Rotate Time")]
    [SerializeField] float time;

    [BoxGroup("Ease Type")]
    [SerializeField] Ease ease;

    [BoxGroup("Loop Options")]
    [SerializeField] LoopType loopType;
    [BoxGroup("Loop Options")]
    [SerializeField] int loopCount;
    void Start()
    {
        if (isRotating)
        {
            RotateMe();
        }
    }

    public void RotateMe()
    {
        transform.DOLocalRotate(new Vector3(valueX, valueY, valueZ), time, rotateMode).SetLoops(loopCount, loopType).SetEase(ease);
    }

}
