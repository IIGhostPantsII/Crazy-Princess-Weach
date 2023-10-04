using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSetup : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    public static int Health;

    void Start()
    {   
        BossCharacter<int>.SetVariable(_health);
        Health = _health;
    }

    public static void ResetEnemy()
    {
        BossCharacter<int>.SetVariable(Health);
        Globals.EnemyAlive();
    }
}
