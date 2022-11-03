using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    private bool _isCollecting;

    private void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (_isCollecting)
            {
                OnPaperCollect();
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            _isCollecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            _isCollecting = false;
        }
    }
}
