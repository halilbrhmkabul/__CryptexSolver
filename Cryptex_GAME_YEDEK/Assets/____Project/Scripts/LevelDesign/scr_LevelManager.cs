using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class scr_LevelManager : Singleton<scr_LevelManager>
{
    
    [Title("---- LEVEL MANAGER ----")]
    
    [Title("Layer Variable")]
    public int LayerCount;
    
    [Title("Number Of Balls At The Start")]
    public int BallSize;
    public int BallSizeSpawn;
    
    [Title(" Number Of Balls To Complete ")]
    public int BallSizeTarget;
    
    
    
}
