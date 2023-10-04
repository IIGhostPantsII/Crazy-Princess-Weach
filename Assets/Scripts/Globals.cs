using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int CurrentLevel = 0;
    public static bool DeathScreen;

    public static void Death()
    {
        DeathScreen = true;
    }
}
