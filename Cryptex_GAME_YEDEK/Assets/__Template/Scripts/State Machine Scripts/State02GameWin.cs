using UnityEngine;
using Pixelplacement;
//using ElephantSDK;


public class State02GameWin : State
{

    private void OnEnable()
    { 
        Debugg.Log("+++ /  Level Completed (Lerp Games) --> Level:" + (DataManager.Instance.Level-1));

        //GameAnalyticsManager.Instance.LevelCompleted(DataManager.Instance.Level-1);
        //Elephant.LevelCompleted(DataManager.Instance.Level-1);

    }




}
