using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] _enemies;
    int[] _lastRand;
    public bool _ifStart;

    // Update is called once per frame
    void Start()
    {
        if(_ifStart)
        {
            StartCoroutine(Delay(1f));
        }
    }

    public IEnumerator Delay(float seconds)
    {
        if(_enemies.Length == 1)
        {
            yield return new WaitForSeconds(seconds);
            _enemies[0].SetActive(true);
        }
        else
        {
            _lastRand = new int[_enemies.Length];
            for(int k = 0; k < _enemies.Length; k++)
            {
                _lastRand[k] = 10000;
            }
            for(int i = 0; i < _enemies.Length / 2; i++)
            {
                yield return new WaitForSeconds(seconds);
                int random = Random.Range(0, _enemies.Length);
                if(i != 0)
                {
                    while(CheckArray(random))
                    {
                        random = Random.Range(0, _enemies.Length);
                    }
                }
                _lastRand[i] = random;
                _enemies[random].SetActive(true);
            }
        }
    }

    private bool CheckArray(int number)
    {
        foreach (int element in _lastRand)
        {
            if (element == number)
            {
                return true;
            }
        }
        return false;
    }
}
