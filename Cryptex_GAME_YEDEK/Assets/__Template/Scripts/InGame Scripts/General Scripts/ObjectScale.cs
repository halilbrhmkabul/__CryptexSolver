using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ObjectScale : MonoBehaviour
{
    [BoxGroup("Scale Active")]
    [SerializeField] bool isScaling;

    [BoxGroup("Scale Value")]
    [SerializeField] float valueX;
    [BoxGroup("Scale Value")]
    [SerializeField] float valueY;
    [BoxGroup("Scale Value")]
    [SerializeField] float valueZ;

    [BoxGroup("Scale Time")]
    [SerializeField] float time;

    [BoxGroup("Ease Type")]
    [SerializeField] Ease ease;

    [BoxGroup("Loop Options")]
    [SerializeField] LoopType loopType;
    [BoxGroup("Loop Options")]
    [SerializeField] int loopCount;
    void Start()
    {
        if (isScaling)
        {
            ScaleMe();
        }
    }

    public void ScaleMe()
    {
        transform.DOScale(new Vector3(valueX, valueY, valueZ), time).SetLoops(loopCount, loopType).SetEase(ease);
    }
 
}
