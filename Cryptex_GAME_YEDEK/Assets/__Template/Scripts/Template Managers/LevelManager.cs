using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Sirenix.OdinInspector;

public class LevelManager : Singleton<LevelManager>
{ 
    [Title("Garbage Object")]
    [SerializeField] GameObject GarbageObject;
     
    [Title("Standart Levels")]
    [SerializeField] List<GameObject> levelList;
     
    [Title("Procedural Levels")]
    [SerializeField] List<GameObject> levelProList;
     
    [Title("Theme Settings")]
    public Color fogColor;


    [System.NonSerialized] public bool LevelRestart;
    int _level ;
    private void OnEnable()
    {
        EventManager.Instance.OnLoadLevel += LoadLevel;

        ThemeExecute();
    }

    private void OnDisable()
    {
        EventManager.Instance.OnLoadLevel -= LoadLevel;
    }

    void LoadLevel()
    {
        // >>> Destroying Garbage
        if (GarbageObject.transform.childCount != 0)
        {
            for (int i = 0; i < GarbageObject.transform.childCount; i++)
            {
                Destroy(GarbageObject.transform.GetChild(i).gameObject);
            }
        }


        // >>> Creating Level Object
        if (levelList.Count == 0 && levelProList.Count == 0) return;
        if (!LevelRestart)
        {
            _level = PlayerPrefs.GetInt("level");
               
            if (_level >= levelList.Count)
            {
                if (levelProList.Count != 0)
                {
                    _level = Random.Range(0, levelProList.Count);
                    Instantiate(levelProList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
                }
                else
                {
                    _level = Random.Range(0, levelList.Count);
                    Instantiate(levelList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
                }

            }
            else
            {
                Instantiate(levelList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
                LevelRestart = false;
            }
        }
        else
        {
            _level = PlayerPrefs.GetInt("level");
            if (_level >= levelList.Count)
            {
                if (levelProList.Count != 0)
                {
                    _level = Random.Range(0, levelProList.Count);
                    Instantiate(levelProList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
                }

                else
                {
                    _level = Random.Range(0, levelList.Count);
                    Instantiate(levelList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
                }

            }
            else if (_level < levelList.Count)
            {
                Instantiate(levelList[_level], Vector3.zero, Quaternion.identity, GarbageObject.transform);
            }

           
            LevelRestart = false;
        }



    }
    public void ThemeExecute()
    {
        RenderSettings.fogColor = fogColor;
    }
}
