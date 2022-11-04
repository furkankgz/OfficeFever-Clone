using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager : MonoBehaviour
{
    public List<GameObject> _paperList = new List<GameObject>(); // olu�an ka��tlar bu listede tutulacak
    public GameObject _paperPrefab; // �retilecek olan ka��t prefab nesnesi
    public Transform _exitPoint; // Spawn olacak ka��tlar�n nerede dizilece�ini g�steren nokta
    private bool _working; // Printer �al���yor mu? �al��m�yor mu?
    private int stackCount = 10;
    
    
    private void Start()
    {
        StartCoroutine(PrintPaper());
    }

    public void RemoveLast()
    {
        if (_paperList.Count > 0)
        {
            Destroy(_paperList[_paperList.Count - 1]);
            _paperList.RemoveAt(_paperList.Count - 1);
        }
    }

    IEnumerator PrintPaper()
    {
        while (true)
        {
            float paperCount = _paperList.Count;
            int rowCount = (int)paperCount / stackCount;
            if (_working)
            {
                GameObject temp = Instantiate(_paperPrefab);
                temp.transform.position = new Vector3(_exitPoint.position.x + ((float)rowCount / 3), (paperCount % stackCount) / 20, _exitPoint.transform.position.z);
                _paperList.Add(temp);
                if (_paperList.Count >= 30)
                {
                    _working = false;
                }
            }
            else if(_paperList.Count < 30)
            {
                _working = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
