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

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;
    public static WorkerManager _workerManager;
    
    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingDesk;
    public static BuyArea _areaToBuy;



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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyingDesk();
            _areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }

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
        if (other.gameObject.CompareTag("BuyArea"))
        {
            _areaToBuy = null;
        }
    }
}
