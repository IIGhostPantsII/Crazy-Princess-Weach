using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSetup : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    void Start()
    {   
        BossCharacter<int>.SetVariable(_health);
    }
}
