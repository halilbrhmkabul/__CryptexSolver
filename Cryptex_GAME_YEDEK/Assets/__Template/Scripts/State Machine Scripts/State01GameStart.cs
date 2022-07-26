using UnityEngine;
using Pixelplacement;

using ElephantSDK;

public class State01GameStart : State
{

    private void OnEnable()
    {
        Debugg.Log("+++ /  Level Started (Lerp Games) --> Level:" + (DataManager.Instance.Level));

        GameAnalyticsManager.Instance.LevelStarted(DataManager.Instance.Level);
        Elephant.LevelStarted(DataManager.Instance.Level);


    }


}
