using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int CurrentLevel = 0;
    public static bool DeathScreen;
    public static bool EnemyDeath;

    //Stats
    public static float FireRate = 0.25f;
    public static float Speed = 1.5f;

    public static void Death()
    {
        DeathScreen = true;
    }

    public static void NoDeath()
    {
        DeathScreen = false;
    }

    public static void AdvanceLevel()
    {
        CurrentLevel++;
    }

    public static void EnemyDead()
    {
        EnemyDeath = true;
    }

    public static void EnemyAlive()
    {
        EnemyDeath = false;
    }

    public static void AddFireRate()
    {
        FireRate /= 1.25f;
    }

    public static void AddSpeed()
    {
        Speed *= 1.1f;
    }
}
