using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using ElephantSDK;

public class State03GameLose : State
{

    private void OnEnable()
    { 
        Debugg.Log("+++ /  Game Lose (Lerp Games) --> Level:" + (DataManager.Instance.Level));


        GameAnalyticsManager.Instance.LevelFailed(DataManager.Instance.Level);
        Elephant.LevelFailed(DataManager.Instance.Level);

        LevelManager.Instance.LevelRestart = true;
    }

 

   
}
