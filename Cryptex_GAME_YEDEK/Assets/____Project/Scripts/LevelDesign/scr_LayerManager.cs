using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pixelplacement;
using Sirenix.OdinInspector; 
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


public class scr_LayerManager : Singleton<scr_LayerManager>
{
    [Title("CRYPTEX SHAPES")] 
   
    [Title("Prefab")]
    public List<GameObject> ShapeObjectList;
   
    [Title("Manager Of This Object")]
    public GameObject layerParent;
    public GameObject PrefabParentLayerObject;
    private GameObject prefabObject;

    private Vector3 startNewRot; 

    public int parentLayerChildCount;
     

     void Awake()
    {
        parentLayerChildCount = PrefabParentLayerObject.transform.childCount;
        for (int j = 0; j < parentLayerChildCount; j++)
        {
            ShapeObjectList.Add(PrefabParentLayerObject.transform.GetChild(j).gameObject); 
        }
        
        for (int i = 0; i < ShapeObjectList.Count ; i++)
        {
            prefabObject = Instantiate(ShapeObjectList[i], new Vector3(0, i, 0),
                Quaternion.identity);
            prefabObject.transform.SetParent(layerParent.transform);
        } 
    }

    private void Start()
    {
        startNewRot = new Vector3(0, transform.rotation.y + scr_PlayerController.Instance.CalculateDegree, 0);

        LayerRotate();
    }
 
    void LayerRotate()
    { 
        for (int i = 0; i < layerParent.transform.childCount; i++)
        {
            layerParent.transform.GetChild(i).transform.DORotate(startNewRot * Random.Range(1, 99), 1f);
        } 
    }
      
}
