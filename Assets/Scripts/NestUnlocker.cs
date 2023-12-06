using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestUnlocker : MonoBehaviour
{
    [SerializeField] GameObject _SNBuy;
    [SerializeField] GameObject _SoNBuy;
    [SerializeField] GameObject _FNBuy;

    public void NestUnlock()
    {
        if(ExpLevel._level == 2)
        {
            _SNBuy.SetActive(true);
        }

        if (ExpLevel._level == 3)
        {
            _SoNBuy.SetActive(true);
        }

        if (ExpLevel._level == 4)
        {
            _FNBuy.SetActive(true);
        }
    }
}
