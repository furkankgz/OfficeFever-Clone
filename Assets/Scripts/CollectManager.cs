using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> _paperList = new List<GameObject>();
    public GameObject _paperPrefab;
    public Transform _collectPoint;


    private void OnEnable()
    {
        //TriggerManager.OnPaperCollect
    }

    private void OnDisable()
    {
        
    }
}
