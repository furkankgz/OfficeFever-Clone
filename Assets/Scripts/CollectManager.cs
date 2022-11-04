using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> _paperList = new List<GameObject>();
    public GameObject _paperPrefab, _moneyPrefab;
    public Transform _collectPoint, _moneyDropPoint;

    private int _paperLimit = 10;

    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += GetPaper;
        TriggerManager.OnPaperGive += GivePaper;
    }

    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= GetPaper;
        TriggerManager.OnPaperGive -= GivePaper;
    }

    private void GetPaper()
    {
        if (_paperList.Count <= _paperLimit)
        {
            GameObject temp = Instantiate(_paperPrefab, _collectPoint);
            temp.transform.position = new Vector3(_collectPoint.position.x, 0.5f + ((float)_paperList.Count / 20), _collectPoint.position.z);
            _paperList.Add(temp);

            if (TriggerManager._printerManager != null)
            {
                TriggerManager._printerManager.RemoveLast();
            }
        }
    }

    private void GivePaper()
    {
        if (_paperList.Count > 0)
        {
            TriggerManager._workerManager.GetPaper();
            RemoveLast();
        }
    }

    public void RemoveLast()
    {
        if (_paperList.Count > 0)
        {
            Destroy(_paperList[_paperList.Count - 1]);
            _paperList.RemoveAt(_paperList.Count - 1);
        }
    }
}
