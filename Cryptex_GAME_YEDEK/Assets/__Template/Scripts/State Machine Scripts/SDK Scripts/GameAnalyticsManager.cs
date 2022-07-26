using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Pixelplacement;

public class GameAnalyticsManager : Singleton<GameAnalyticsManager>
{

    void Start()
    {
        GameAnalytics.Initialize();
    }

    public void LevelStarted(int startedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "GameAnalytics Started Level " + startedLevel);
    }

    public void LevelFailed(int failedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "GameAnalytics Failed Level  " + failedLevel);
    }

    public void LevelCompleted(int completedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GameAnalytics Completed Level " + completedLevel);
    }
    public void GameClose(int completedLevel)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Undefined, "GameAnalytics Closed Level" + completedLevel);
    }


}