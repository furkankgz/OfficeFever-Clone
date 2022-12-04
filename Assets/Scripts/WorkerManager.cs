using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> _paperList = new List<GameObject>();
    public List<GameObject> _moneyList = new List<GameObject>();
    public Transform _paperPoint, _moneyDropPoint;
    public GameObject _paperPrefab, _moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (_paperList.Count > 0)
            {
                GetMoney();
                RemoveLast();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void GetPaper()
    {
        GameObject temp = Instantiate(_paperPrefab);
        temp.transform.position = new Vector3(_paperPoint.position.x, 0.8f + ((float)_paperList.Count / 20), _paperPoint.position.z);
        _paperList.Add(temp);
    }

    public void GetMoney()
    {
        GameObject temp = Instantiate(_moneyPrefab);
        temp.transform.position = new Vector3(_moneyDropPoint.position.x, ((float)_moneyList.Count / 20), _moneyDropPoint.position.z);
        _moneyList.Add(temp);
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
