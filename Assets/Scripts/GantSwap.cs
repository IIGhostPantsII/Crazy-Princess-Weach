using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GantSwap : MonoBehaviour
{
    public GameObject _wall;
    public GameObject _gateway;

    public static bool DoTheSwap;

    void Update()
    {
        if(DoTheSwap)
        {
            Swap();
            DoTheSwap = false;
        }
    }
    
    public static void ItsBeenDone()
    {
        DoTheSwap = true;
    }

    void Swap()
    {
        _wall.SetActive(false);
        _gateway.SetActive(true);
    }
}
