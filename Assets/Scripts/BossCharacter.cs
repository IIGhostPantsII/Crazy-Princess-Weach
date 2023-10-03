using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BossCharacter<SoTrue>
{
    public static SoTrue _variable;
    public static int _intVariable;
    public static string _stringVariable;
    public static bool _boolVariable;

    public static bool _dead;

    public static void SetVariable(SoTrue value)
    {
        if(typeof(SoTrue) == typeof(int))
        {
            _intVariable = (int)(object)value;
        }
        else if(typeof(SoTrue) == typeof(string))
        {
            _stringVariable = (string)(object)value;
        }
        else if(typeof(SoTrue) == typeof(bool))
        {
            _boolVariable = (bool)(object)value;
        }
        else
        {
            _variable = value;
        }
    }

    public static SoTrue GetVariable()
    {
        return _variable;
    }

    public static void SubtractHealth(int damage)
    {
        _intVariable -= damage;

        if(_intVariable < 1)
        {
            _dead = true;
        }
    }
}