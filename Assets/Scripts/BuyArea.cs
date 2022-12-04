using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyArea : MonoBehaviour
{
    public GameObject _deskGameObject, _buyGameObject;
    public float _cost, _currentMoney, _progress;

    public void Buy(int goldAmount)
    {
        _currentMoney += goldAmount;
        _progress = _currentMoney / _cost;

        if (_progress >= 1)
        {
            _buyGameObject.SetActive(false);
            _deskGameObject.SetActive(true);
            this.enabled = false;
        }
    }
}
