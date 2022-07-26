using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class ObjectMove : MonoBehaviour
{
    [BoxGroup("Move Active")]
    [SerializeField] bool isMoving;

    [BoxGroup("Move Value")]
    [SerializeField] float valueX;
    [BoxGroup("Move Value")]
    [SerializeField] float valueY;
    [BoxGroup("Move Value")]
    [SerializeField] float valueZ;

    [BoxGroup("Move Time")]
    [SerializeField] float time;

    [BoxGroup("Ease Type")]
    [SerializeField] Ease ease;

    [BoxGroup("Loop Options")]
    [SerializeField] LoopType loopType;
    [BoxGroup("Loop Options")]
    [SerializeField] int loopCount;
    
    [BoxGroup("Delay options")]
    [SerializeField] float delayTime;
    [BoxGroup("Delay options")]
    [SerializeField] bool randomDelay;
    void Start()
    {
        if (isMoving)
        {
            if (randomDelay)
            {
                delayTime = Random.Range(0, delayTime);
            }

            MoveMe();
        }
    }

    public void MoveMe()
    {
        transform.DOLocalMove(new Vector3(valueX, valueY, valueZ), time).SetLoops(loopCount, loopType).SetEase(ease).SetDelay(delayTime);
    }

}
