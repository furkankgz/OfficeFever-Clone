using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();    
    public static event OnCollectArea OnPaperCollect;
    public static PrinterManager _printerManager;
    private bool _isCollecting, _isGiving;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperGive;

    public static WorkerManager _workerManager;

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

            if (_isGiving)
            {
                OnPaperGive();
            }

            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            _isCollecting = true;
            _printerManager = other.gameObject.GetComponent<PrinterManager>();
        }

        if (other.gameObject.CompareTag("WorkArea"))
        {
            _isGiving = true;
            _workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            _isCollecting = false;
            _printerManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            _isGiving = false;
            _workerManager = null;
        }
    }
}
