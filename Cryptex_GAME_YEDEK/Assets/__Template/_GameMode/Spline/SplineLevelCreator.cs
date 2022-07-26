using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SplineLevelCreator : MonoBehaviour
{
    [Header("Spline Component Variables")]
    SplineFollower _splineFollower;
    [SerializeField] List<SplineComputer> splineComputer; int randomSplineComputer;
 
    [SerializeField] List<SplineMesh> splineMesh;
      

   // [Header("Spline Mesh")]

   // [SerializeField] int splineMeshCount;

    //[Header("Spline Range")]
    //[SerializeField] float splineRangeX;
    //[SerializeField] float splineRangeY;

    [Header("Spline Follower")]
    [SerializeField] float splineFollowSpeed;

    [Header("Object Creator")]
    [SerializeField] List<GameObject> objectCreator;
    [SerializeField] int objectCreatorDistance;
    SplinePositioner _splinePositioner;

    private void OnEnable()
    {
        EventManager.Instance.OnTapToPlay += TapToPlay;
        EventManager.Instance.OnGameWin += GameWin;
        EventManager.Instance.OnGameLose += GameLose;
        EventManager.Instance.OnLoadLevel += LoadLevel;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnTapToPlay -= TapToPlay;
        EventManager.Instance.OnGameWin -= GameWin;
        EventManager.Instance.OnGameLose -= GameLose;
        EventManager.Instance.OnLoadLevel -= LoadLevel;
    }

    void TapToPlay()
    {
        _splineFollower.followSpeed = splineFollowSpeed;
    }

    void GameWin(int coin)
    {
        _splineFollower.followSpeed = 0;
    }

    void GameLose(int coin)
    {
        _splineFollower.followSpeed = 0;
    }

    void LoadLevel()
    {
        _splineFollower.SetPercent(0);
    }

    void Start()
    {
        SplineGet();
    }

    void SplineGet()
    {  
        randomSplineComputer = Random.Range(0,splineComputer.Count);

        SplineMeshCreate();
    }


    void SplineMeshCreate()
    {
        for (int i = 0; i < splineMesh.Count; i++)
        {

            splineMesh[i].gameObject.SetActive(true);
            splineMesh[i].spline = splineComputer[randomSplineComputer];
          //  splineMesh[i].GetChannel(0).count = splineMeshCount;
        } 
        SplineFollowerSet();
    }

    void SplineFollowerSet()
    {
        _splineFollower = GameManager.Instance.PlayerObject.GetComponent<SplineFollower>();
        _splineFollower.spline = splineComputer[randomSplineComputer];

        if(objectCreator.Count!=0)
        ObjectCreator(objectCreatorDistance);
    }

    void ObjectCreator(float objectDistance)
    {
        for (float i = splineComputer[randomSplineComputer].GetPointPosition(1).z; 
                i < splineComputer[randomSplineComputer].GetPointPosition(splineComputer[randomSplineComputer].pointCount   - 1).z;
                    i += objectDistance)
        {
            GameObject cloneObject = Instantiate(objectCreator[Random.Range(0,objectCreator.Count)]);

            
            cloneObject.transform.SetParent(transform);
            cloneObject.transform.localPosition = transform.localPosition;
            cloneObject.transform.eulerAngles = transform.localEulerAngles; 
            cloneObject.gameObject.SetActive(true); 

            _splinePositioner =cloneObject.GetComponent<SplinePositioner>();
            _splinePositioner.spline = splineComputer[randomSplineComputer];
            _splinePositioner.SetDistance(i);
        
            _splinePositioner.Rebuild();
        }

        
    }
}
